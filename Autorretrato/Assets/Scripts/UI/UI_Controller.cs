using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    public GameObject endGameScreen;
    public GameObject winScreen;
    public GameObject HUD;
    public GameObject clock;
    public GameObject volumeScreen;
    AudioSource audioSource_Click;
    public Timer_Controller timeController;
    public TMP_Text gameOverTxt;
    public TMP_Text gameOverTxt_Shadow;

    private void Start()
    {
        audioSource_Click = GetComponent<AudioSource>();
    }

    public void openVolumeManager()
    {
        audioSource_Click.Play();
        if (volumeScreen.activeInHierarchy)
        {
            timeController.reduceTime = true;
            volumeScreen.SetActive(false);
            HUD.SetActive(true);
            clock.SetActive(true);
            Time.timeScale = 1f;
        }
        else
        {
            timeController.reduceTime = false;
            volumeScreen.SetActive(true);
            HUD.SetActive(false);
            clock.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void showWinningScreen()
    {
        if(!endGameScreen.activeInHierarchy)
        {
            winScreen.SetActive(true);
            HUD.SetActive(false);
            clock.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void showEndGameScreen(string txtGameOver)
    {
        if (!endGameScreen.activeInHierarchy && !winScreen.activeInHierarchy)
        {
            gameOverTxt.text = txtGameOver;
            gameOverTxt_Shadow.text = txtGameOver;
            endGameScreen.SetActive(true);
            HUD.SetActive(false);
            clock.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void backToMainMenu()
    {
        audioSource_Click.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Jugar()
    {
        Time.timeScale = 1f;
        audioSource_Click.Play();
        SceneManager.LoadScene("Room");
    }

    public void Salir()
    {
        audioSource_Click.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
                                            Application.Quit();
        #endif
    }
}
