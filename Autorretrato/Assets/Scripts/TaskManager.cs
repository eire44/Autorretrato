using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : PuzzleManager
{
    public override bool puzzleTaskCompleted { get => base.puzzleTaskCompleted; set => base.puzzleTaskCompleted = value; }
    public GameObject taskUI;
    

    public void openTaskUI()
    {
        taskUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void closeTaskUI()
    {
        taskUI.SetActive(false);
        Time.timeScale = 1f;
        //bajar energia
        checkIfTaskCompleted();
    }

    public override void checkIfTaskCompleted()
    {
        bool allDropZonesCorrect = true;
        foreach (Transform UIitem in taskUI.transform)
        {
            DropZone dropZone = UIitem.GetComponent<DropZone>();
            if (dropZone != null)
            {
                if(!dropZone.draggablePlaced)
                {
                    allDropZonesCorrect = false;
                    return;
                }
            }
        }

        if (allDropZonesCorrect)
        {
            endTask();
        }
    }

    void endTask()
    {
        Transform bubble = transform.Find("Bubble");
        bubble.gameObject.SetActive(false);
        gameObject.layer = LayerMask.NameToLayer("Default");
        FindObjectOfType<Player_Interact>().taskCompleted();
        FindObjectOfType<GameManager>().taskCompleted();
    }
}
