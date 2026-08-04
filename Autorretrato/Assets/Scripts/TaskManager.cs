using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject taskUI;
    public GameObject HUD;
    public bool isAgenda;
    public AudioSource uiClick;
    public string txtDialog;
    Dialogs_Controller dialogsController; 
    GameManager gm;

    private void Start()
    {
        dialogsController = FindObjectOfType<Dialogs_Controller>();
        gm = FindObjectOfType<GameManager>();
    }

    public void openTaskUI()
    {
        uiClick.Play();
        taskUI.SetActive(true);
        HUD.SetActive(false);
        gm.reduceEnergy(false);
        Time.timeScale = 0f;
    }

    public void closeTaskUI()
    {
        uiClick.Play();
        taskUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        
        PuzzleManager checkTask = gameObject.GetComponent<PuzzleManager>();
        checkTask.feedbackBubble.SetActive(false);
        
        if (checkTask != null)
        {
            if (checkTask.puzzleSolved)
            {
                endTask();

                if (isAgenda)
                {
                    gm.saveSelectedTasks();
                    gm.activateTasks();
                }
                else
                {
                    gm.reduceEnergy(true);
                    gm.taskCompleted();
                }
                dialogsController.changeDialogTxt("You did it!! One task less, " + gm.tasksLeft + " to go.");
            }
            //else
            //{
            //    gm.reduceEnergy(false);
            //}
        }
    }

    void endTask()
    {
        Transform bubble = transform.Find("Bubble");
        bubble.gameObject.SetActive(false);
        gameObject.layer = LayerMask.NameToLayer("Default");
        FindObjectOfType<Player_Interact>().taskCompleted();
    }
}
