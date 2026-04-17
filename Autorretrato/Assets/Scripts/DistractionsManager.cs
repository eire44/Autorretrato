using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionsManager : MonoBehaviour
{
    public GameObject distractionUI;
    public GameObject HUD;
    public bool isAgenda;

    public void openTaskUI()
    {
        distractionUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    public void closeTaskUI()
    {
        distractionUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        //subir energia

        //PuzzleManager checkTask = gameObject.GetComponent<PuzzleManager>();
        //if (checkTask != null)
        //{
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
