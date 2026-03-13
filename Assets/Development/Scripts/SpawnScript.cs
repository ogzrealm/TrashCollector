using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private List<Transform> SpawnPoints;
    [SerializeField] private GameObject boostItem;
    private GameObject spawnItem;
    
    private void Start()
    {
        RandomSpawn();
    }
    
    private void RandomSpawn()
    {
        int randomIndex = Random.Range(0, SpawnPoints.Count-1);
        spawnItem = Instantiate(boostItem, SpawnPoints[randomIndex].position, SpawnPoints[randomIndex].rotation);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("araçla temas oldu");
            Destroy((spawnItem));
            RandomSpawn();
        }
    }
}
