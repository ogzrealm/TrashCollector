using System;
using System.Collections;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private TextMeshProUGUI inventoryText;
    private IEnumerator warningCoroutine;
    private IEnumerator dropHereCoroutine;
    [SerializeField] private RectTransform scoreTxtScale, timeTxtScale;
    public static UIManagerScript instance;
    [SerializeField] private TextMeshProUGUI dropHereText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private  GameObject GameOverPanel;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void addtoTxtScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        finalScoreText.text = "Final Score: " + score.ToString();
        StartCoroutine(ScoreTextAnimation());
        setHighScore(score);
    }

    public void addtoTxtInventory(int inventory)
    {
        inventoryText.text = "Inventory: " + inventory.ToString() +"/5";
    }

    public IEnumerator ScoreTextAnimation()
    {
        Vector3 originalScale = scoreTxtScale.localScale;
        scoreTxtScale.localScale = originalScale * 1.15f;
        
        yield return new WaitForSeconds(0.15f);
        
        scoreTxtScale.localScale = originalScale;

    }

    private IEnumerator TimeAniCoroutine()
    {
        Vector3 originalScale= timeTxtScale.localScale;
        timeTxtScale.localScale = originalScale * 1.15f;
        
        yield return new WaitForSeconds(0.15f);
        
        timeTxtScale.localScale = originalScale;
    }

    public void timeAnimation()
    {
        StartCoroutine(TimeAniCoroutine());
    }
    public void addtoTxtTime(float time)
    {
        timeText.text = "Time: " + Mathf.FloorToInt(time).ToString();
    }
    
    private IEnumerator capacityWarningAnimation()
    {
        
        warningText.gameObject.SetActive(true);
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            warningText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.6f);
            warningText.gameObject.SetActive(true); 
        }

    }

    public void capacityWarning()
    {
        if (warningCoroutine == null)
        {
            warningCoroutine = capacityWarningAnimation();
            StartCoroutine(warningCoroutine);
        }
        
    }

    public void silencecapacityWarning()
    {
        if (warningCoroutine != null)
        {
            StopCoroutine(warningCoroutine); 
            warningCoroutine = null;
            warningText.gameObject.SetActive(false);
        }
    }

    public void StationDropText()
    {
        if (dropHereCoroutine == null)
        {
            dropHereCoroutine = dropHereAnimation();
            StartCoroutine(dropHereCoroutine);
        }
    }

    public void StationDropTextFalse()
    {
        if (dropHereCoroutine != null)
        {
            StopCoroutine(dropHereCoroutine); 
            dropHereCoroutine = null;
            dropHereText.gameObject.SetActive(false);
        }
    }

    private IEnumerator dropHereAnimation()
    {
        dropHereText.gameObject.SetActive(true);
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            dropHereText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.6f);
            dropHereText.gameObject.SetActive(true); 
        }
    }
    

    private void setHighScore(int score) 
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore=score;
        }
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void GameOverStatus()
    {
        scoreText.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
        inventoryText.gameObject.SetActive(false);
        GameOverPanel.SetActive(true);
        
    }

    public void RestartGameButton()
    {
        AudioManagerScript.instance.ResetButtonSound();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

