using System;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    private InventoryScript _inventory;
    private TrashSpawnScript _trashSpawn;

    private void Start()
    { 
        _inventory = FindObjectOfType<InventoryScript>();
        _trashSpawn = FindObjectOfType<TrashSpawnScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _inventory.isFullCapasity==false)
        {
            AudioManagerScript.instance.TrashPickUpSound();
            _inventory.addInventory();
            _trashSpawn.SingleTrashSpawn();
            Destroy(gameObject);
        }
    }
}
