using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionsManager : MonoBehaviour
{
    public GameObject distractionUI;
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
        distractionUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    public void closeTaskUI()
    {
        uiClick.Play();
        distractionUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        //subir energia
        dialogsController.changeDialogTxt(txtDialog);

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
