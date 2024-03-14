using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // crear variables publicas para poder manipular desde el inspector

    public float playerJumpForce = 19f;
    public float playerSpeed = 5f;
    public Sprite[] myRunSprites;
    private int index = 0;
    public Sprite[] myDeathSprites;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameManager myGameManager;
    public GameObject Bullet;


    //para audio
    public AudioManager audioManager;
    public AudioClip sonidoSaltar;
    public AudioClip sonidoAtacar;
    public AudioClip sonidoMorirJugador;
    public AudioClip sonidoMorirEnemigo;
    public AudioClip sonidoMoneda;


    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine()); // inicia a correr
        //para que no gire
        myrigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // saltar
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
            audioManager.ReproducirSonido(sonidoSaltar);
        }
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);

        // balas
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            audioManager.ReproducirSonido(sonidoAtacar);
        }
    }

    // Animación de correr
    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = myRunSprites[index]; // Set the sprite
        index++;
        if (index == myRunSprites.Length)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }


    // para detectar colisiones --> cosas buenas, malas y zona de muerte
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            audioManager.ReproducirSonido(sonidoMoneda);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            audioManager.ReproducirSonido(sonidoMorirEnemigo);
            
            PlayerDeath();
        }
        else if (collision.CompareTag("Deathzone"))
        {
            PlayerDeath();
        }
    }


    // jugador muere :(
    IEnumerator PlayerDeathRoutine()
    {
        audioManager.ReproducirSonido(sonidoMorirJugador);
        StartCoroutine(DeathCoRutine()); //agregar la animación para morir 
        // Esperar que el sonido termine antes de cargar la nueva escena.
        yield return new WaitForSeconds(1f); // esperar para que suene la musica y salga la animación
        SceneManager.LoadScene("Level2D"); //carga el nuevo nivel
    }

    void PlayerDeath()
    {
        StartCoroutine(PlayerDeathRoutine());
    }


    // animación para morir
        IEnumerator DeathCoRutine()
    {
        yield return new WaitForSeconds(0f);
        mySpriteRenderer.sprite = myDeathSprites[index];
        index++;
        if (index == myDeathSprites.Length)
        {
            index = 0;
        }
        StartCoroutine(DeathCoRutine());
    }






}