using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionsManager : MonoBehaviour
{
    [HideInInspector] public GameObject distractionUI;
    public GameObject HUD;
    //public bool isAgenda;
    public AudioSource uiClick;
    public AudioSource distractionFeedback;
    public GameObject bubbleFeedback;

    public void openTaskUI(GameObject distractionScreen)
    {
        distractionUI = distractionScreen;
        uiClick.Play();
        distractionUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    public void activateFeedback(bool puzzleComplete)
    {
        if (puzzleComplete)
        {
            distractionFeedback.Play();
        }
        bubbleFeedback.SetActive(puzzleComplete);
    }
}
