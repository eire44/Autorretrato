using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTask_ReadBook : PuzzleManager
{
    int orderId = 0;
    public GameObject taskScreen;
    //[HideInInspector] public override bool puzzleSolved = false;
    bool playAudioOnce = false;

    private void Update()
    {
        if (taskScreen.activeInHierarchy)
        {
            if(checkIfTaskCompleted(taskScreen))
            {
                puzzleSolved = true;

                if (!playAudioOnce)
                {
                    taskDone.Play();
                    playAudioOnce = true;
                }
            } else
            {
                puzzleSolved = false;
                playAudioOnce = false;
            }
        }
    }

    public override bool checkIfTaskCompleted(GameObject taskUI) //podrían ser llamados en updates mientras la screen esté activa
    {
        foreach (Transform UIitem in taskUI.transform)
        {
            DropZone dropZone = UIitem.GetComponent<DropZone>();
            if (dropZone != null)
            {
                if (!dropZone.draggablePlaced)
                {
                    Debug.Log("draggable sin placear");
                    return false;
                }
                else
                {
                    Debug.Log(dropZone.idCorrecto + " vs. ");
                    Debug.Log(orderId);
                    if (dropZone.idCorrecto == orderId)
                    {
                        orderId++;
                    }
                    else
                    {
                        orderId = 0;
                        Debug.Log("id incorrecto");
                        return false;
                    }
                }
            }
        }

        return true;
    }
}
