using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject howtoplayPanel;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip playSound, howtoplaySound, backSound, quitSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        highScoretoText();
    }
    
    private void highScoretoText()
    {
        int highscore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Your High Score: " + highscore.ToString();
    }

    public void PlayButton()
    {
        _audioSource.PlayOneShot(playSound);
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlay()
    {
        _audioSource.PlayOneShot(howtoplaySound);
        howtoplayPanel.SetActive(true);
    }

    public void BackButton()
    {
        _audioSource.PlayOneShot(backSound);
        howtoplayPanel.SetActive(false);
    }
    
    public void QuitButton()
    {
        _audioSource.PlayOneShot(quitSound);
        Application.Quit();
    }
}
