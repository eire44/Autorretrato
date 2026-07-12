using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractions_UI : MonoBehaviour
{
    public GameObject distractionScreen;
    public string txtDialog;
    DistractionsManager distractionsManager;
    [HideInInspector] public bool distractionToTask = false;
    [HideInInspector] public bool puzzleSolved = false;

    public DistractionsManager DistractionsManager;
    Dialogs_Controller dialogsController;


    private void Start()
    {
        distractionsManager = FindObjectOfType<DistractionsManager>();
        dialogsController = FindObjectOfType<Dialogs_Controller>();
    }

    public void openTaskUI()
    {
        distractionsManager.openTaskUI(distractionScreen);
    }

    public void closeTaskUI()
    {
        DistractionsManager.uiClick.Play();
        distractionScreen.SetActive(false);
        DistractionsManager.HUD.SetActive(true);
        DistractionsManager.bubbleFeedback.SetActive(false);
        Time.timeScale = 1f;

        if(distractionToTask)
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (puzzleSolved)
            {
                endTask();
                gm.reduceEnergy(true);
                gm.taskCompleted();
                dialogsController.changeDialogTxt("You did it!! One task less, " + gm.tasksLeft + " to go.");
            }
            else
            {
                gm.reduceEnergy(false);
            }
        }

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



    void endTask()
    {
        Transform bubble = transform.Find("Bubble");
        bubble.gameObject.SetActive(false);
        gameObject.layer = LayerMask.NameToLayer("Default");
        FindObjectOfType<Player_Interact>().taskCompleted();
    }
}
