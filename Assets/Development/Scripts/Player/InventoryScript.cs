using System;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private int _maxTrash = 5;
    [HideInInspector] public bool isFullCapasity = false;
    [SerializeField] private int currentTrash;
    [SerializeField] private int score;
    private UIManagerScript uiManager;
    private TrashHoleScript TrashHoleScript;

    private void Start()
    {
        uiManager=FindObjectOfType<UIManagerScript>();
        TrashHoleScript = FindObjectOfType<TrashHoleScript>();
    }

    public void addInventory()
    {
        currentTrash++;
        if (currentTrash >= _maxTrash)
        {
            isFullCapasity = true;
            uiManager.capacityWarning();
            uiManager.StationDropText();
            AudioManagerScript.instance.CapacityWarningSound(true);
            
            return;
        }
        
        isFullCapasity = false;
        Debug.Log(currentTrash);
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StationTag"))
        {
            if (currentTrash > 0)
            {
                AudioManagerScript.instance.TrashDropSound();
                addScore();
                Debug.Log("Delivered Trash: " + currentTrash);
                currentTrash = 0;
                uiManager.silencecapacityWarning();
                uiManager.StationDropTextFalse();
                TrashHoleScript.HoleColorChange();
                AudioManagerScript.instance.CapacityWarningSound(false);
                isFullCapasity = false;
            }
            
        }
    }

    private void addScore()
    {
        score += currentTrash * 10;
        uiManager.addtoTxtScore(score);
    }
}
