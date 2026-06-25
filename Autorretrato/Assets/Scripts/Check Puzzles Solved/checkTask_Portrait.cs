using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTask_Portrait : PuzzleManager
{
    public GameObject taskScreen;
    bool playAudioOnce = false;

    private void Update()
    {
        if (taskScreen.activeInHierarchy)
        {
            if (checkIfTaskCompleted(taskScreen))
            {
                puzzleSolved = true;

                if (!playAudioOnce)
                {
                    taskDone.Play();
                    playAudioOnce = true;
                    feedbackBubble.SetActive(true);
                }
            }
            else
            {
                puzzleSolved = false;
                playAudioOnce = false;
                feedbackBubble.SetActive(false);
            }
        }
    }

    public override bool checkIfTaskCompleted(GameObject taskUI)
    {
        foreach (Transform UIitem in taskUI.transform)
        {
            DropZone dropZone = UIitem.GetComponent<DropZone>();
            DraggableObject draggable = UIitem.GetComponent<DraggableObject>();
            if (dropZone != null && draggable != null)
            {
                if (!draggable.draggablePlaced)
                {
                    return false;
                }
                else
                {
                    if(dropZone.idCorrecto != -1)
                    {
                        if (int.Parse(draggable.id) + 1 != dropZone.idCorrecto)
                        {
                            return false;
                        }
                    }
                    
                }
            }
        }
        
        return true;
    }
}
