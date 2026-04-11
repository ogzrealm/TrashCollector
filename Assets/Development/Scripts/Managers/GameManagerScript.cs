using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public float time = 60f;
    private UIManagerScript uiManager;
    public static GameManagerScript Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        uiManager=FindObjectOfType<UIManagerScript>();
    }

    void Update()
    {
        countdown();
    }
    
    private void countdown()
    {
        time -= Time.deltaTime;
        uiManager.addtoTxtTime(time);
        if (time <= 0)
        {
            Debug.Log("Game Over");
            time = 0;
            Time.timeScale = 0;
            CarControlScript car=FindObjectOfType<CarControlScript>();
            car.ResetPitch();
            car.StopEngine();
        }
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if(Time.timeScale == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
