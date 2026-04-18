using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public GameObject endGameScreen;
    public GameObject HUD;
    public GameObject volumeScreen;
    AudioSource audioSource_Click;

    private void Start()
    {
        audioSource_Click = GetComponent<AudioSource>();
    }

    public void openVolumeManager()
    {
        audioSource_Click.Play();
        if (volumeScreen.activeInHierarchy)
        {
            volumeScreen.SetActive(false);
            HUD.SetActive(true);
            Time.timeScale = 1f;
        }
        else
        {
            volumeScreen.SetActive(true);
            HUD.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void showEndGameScreen()
    {
        endGameScreen.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    public void backToMainMenu()
    {
        audioSource_Click.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Jugar()
    {
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
