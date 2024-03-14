using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // plataformas
    public GameObject[] platformPrefabs;
    public float minTime = 1f;
    public float maxTime = 2f;
    public float minY = -1.5f;
    public float maxY = 1.5f;
    public float distanceBetweenPlatforms = 4f;

    private float nextSpawnX;

    //items
    public ItemSpawner itemSpawner; // Referencia al ItemSpawner
    public float itemSpawnProbability = 0.8f; // Probabilidad de generar un ítem en una plataforma

    void Start()
    {
        nextSpawnX = transform.position.x;
        StartCoroutine(SpawnCoRoutine());
    }

    IEnumerator SpawnCoRoutine()
    {
        while (true)
        {
            float randomY = Random.Range(minY, maxY);

            // Instancia una nueva plataforma
            GameObject newPlatform = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector3(nextSpawnX, randomY, 0), Quaternion.identity); // inicia cogiendo cualquier plataforma de la lista, desde 0 hasta el largo de la lista, y crea un nuevo vector en las 3 posiciones, nextSwpawnX es el valor horizontal sacado con transform.position.x, la random y y 0 en z, poniendo el quaternion al final no se por que 

            // Decide si generar un ítem en esta plataforma basado en la probabilidad
            if (Random.value < itemSpawnProbability)
            {
                float fixedItemSpawnY = randomY + 1.4f; // ítems se coloquen correctamente encima de las plataformas

                // Llama a SpawnItem en la posición calculada
                Vector3 itemSpawnPosition = new Vector3(nextSpawnX, fixedItemSpawnY, 0);
                itemSpawner.SpawnItem(itemSpawnPosition);
            }

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            nextSpawnX += distanceBetweenPlatforms;
        }
    }
}