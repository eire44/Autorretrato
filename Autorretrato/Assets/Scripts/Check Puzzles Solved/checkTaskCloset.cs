using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class checkTaskCloset : PuzzleManager
{
    public dzGroupsList dzGroupsList;
    public GameObject clothes;
    public GameObject taskScreen;
    bool playAudioOnce = false;

    private void Update()
    {
        if (taskScreen.activeInHierarchy)
        {
            if (checkIfTaskCompleted(taskScreen))
            {
                if (!playAudioOnce)
                {
                    playAudioOnce = true;
                    puzzleSolved = true;
                    activateFeedback(true, feedbackBubble);
                }
            }
            else
            {
                playAudioOnce = false;
                puzzleSolved = false;
                activateFeedback(false, feedbackBubble);
            }
        }
    }

    public override bool checkIfTaskCompleted(GameObject taskUI)
    {
        foreach (DropZoneGroups dzG in dzGroupsList.dzGroups)
        {
            int groupID = -1;
            bool takeOneID = true;
            foreach (DropZone dz in dzG.dzGroups)
            {
                if (dz.draggablePlaced)
                {
                    if (takeOneID)
                    {
                        takeOneID = false;
                        groupID = dz.idCorrecto;
                    }
                    if (dz.idCorrecto != groupID)
                    {
                        return false;
                    }
                }
            }
        }

        DraggableObject[] draggables = clothes.GetComponentsInChildren<DraggableObject>();

        foreach (DraggableObject d in draggables)
        {
            if (!d.draggablePlaced)
            {
                return false;
            }
        }

        return true;
    }
}
