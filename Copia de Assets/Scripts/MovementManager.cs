using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    public Sprite[] mySprites;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TurnCoRutine());
    }

    // Update is called once per frame
    IEnumerator TurnCoRutine()
    {
        while (true) // Este bucle mantiene la corutina ejecutándose continuamente
        {
            yield return new WaitForSeconds(0.05f); // Espera antes de cambiar el sprite
            mySpriteRenderer.sprite = mySprites[index]; // Cambia el sprite
            index++;
            if (index >= mySprites.Length) // Si alcanzaste el final del arreglo, reinicia el índice
            {
                index = 0;
            }
        }
    }
}
