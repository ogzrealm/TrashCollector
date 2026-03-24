using System;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private int _maxTrash = 5;
    [SerializeField] private int currentTrash;
    public void addInventory()
    {
        if (currentTrash < _maxTrash)
        {
            currentTrash++;
            Debug.Log(currentTrash);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StationTag"))
        {
            currentTrash = 0;
        }
    }
}
