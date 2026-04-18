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

    private void Start()
    {
        dialogsController = FindObjectOfType<Dialogs_Controller>();
    }

    public void openTaskUI()
    {
        uiClick.Play();
        taskUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    public void closeTaskUI()
    {
        uiClick.Play();
        taskUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        //bajar energia
        PuzzleManager checkTask = gameObject.GetComponent<PuzzleManager>();
        GameManager gm = FindObjectOfType<GameManager>();
        if (checkTask != null)
        {
            if (checkTask.checkIfTaskCompleted(taskUI))
            {
                endTask();
                dialogsController.changeDialogTxt("...");
                if (isAgenda)
                {
                    gm.activateTasks();
                }
                else
                {
                    gm.taskCompleted();
                    gm.reduceEnergy(true);
                }
            }
            else
            {
                dialogsController.changeDialogTxt(txtDialog);
                gm.reduceEnergy(true);
            }
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
