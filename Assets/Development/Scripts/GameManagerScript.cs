using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private float time = 60f;

    void Update()
    {
        countdown();
    }
    
    private void countdown()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
