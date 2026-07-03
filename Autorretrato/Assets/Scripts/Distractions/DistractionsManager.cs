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

    public void closeTaskUI()
    {
        uiClick.Play();
        distractionUI.SetActive(false);
        HUD.SetActive(true);
        bubbleFeedback.SetActive(false);
        Time.timeScale = 1f;

        //PuzzleManager checkTask = gameObject.GetComponent<PuzzleManager>();
        //if (checkTask != null)
        //{
        //    checkTask.checkIfTaskCompleted(distractionUI);
        //    if (checkTask.checkIfTaskCompleted(taskUI))
        //    {
        //        endTask();
        //        GameManager gm = FindObjectOfType<GameManager>();
        //        if (isAgenda)
        //        {
        //            gm.activateTasks();
        //        }
        //        else
        //        {
        //            gm.taskCompleted();
        //        }
        //    }
        //}
    }
}
