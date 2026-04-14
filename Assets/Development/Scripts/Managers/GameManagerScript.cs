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
        if (time <= 0) return;
        time -= Time.deltaTime;
        
        if (time <= 0)
        {
            time = 0;
            Time.timeScale = 0;
            CarControlScript car=FindObjectOfType<CarControlScript>();
            car.ResetPitch();
            car.StopEngine();
            GameOver();
            return;
        }
        uiManager.addtoTxtTime(time);
    }


    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        if(Time.timeScale == 0)
        {
            UIManagerScript.instance.GameOverStatus();
        }
    }
}
