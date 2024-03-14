using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Incluye tanto ítems buenos como malos
    public float spawnRate = 0.7f; // Probabilidad de generar un ítem

    public void SpawnItem(Vector3 spawnPosition)
    {
        if (Random.value < spawnRate)
        {
            Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], spawnPosition, Quaternion.identity);
        }
    }
}
