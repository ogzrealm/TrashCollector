using System;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private int _maxTrash = 5;
    [HideInInspector] public bool isFullCapasity = false;
    [SerializeField] private int currentTrash;
    [SerializeField] private int score;
    public void addInventory()
    {
        if (currentTrash == _maxTrash)
        {
            isFullCapasity = true;
        }
        else if (currentTrash < _maxTrash && !isFullCapasity)
        {
            currentTrash++;
            Debug.Log(currentTrash);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StationTag"))
        {
            if (currentTrash > 0)
            {
                addScore();
                Debug.Log("Delivered Trash: " + currentTrash);
                currentTrash = 0;
                isFullCapasity = false;
            }
            
        }
    }

    private void addScore()
    {
        score += currentTrash * 10;
    }
}
