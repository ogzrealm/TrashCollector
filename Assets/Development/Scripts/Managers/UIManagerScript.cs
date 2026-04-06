using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI warningText;
    private IEnumerator warningCoroutine;
    [SerializeField] private RectTransform scoreTxtScale;

    private void Start()
    {
        
    }

    public void addtoTxtScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        StartCoroutine(scoreTextAnimation());
    }

    private IEnumerator scoreTextAnimation()
    {
        Vector3 originalScale = scoreTxtScale.localScale;
        scoreTxtScale.localScale = originalScale * 1.2f;
        
        yield return new WaitForSeconds(0.2f);
        
        scoreTxtScale.localScale = originalScale;

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
}

