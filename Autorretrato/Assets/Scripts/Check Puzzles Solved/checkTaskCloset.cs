using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class checkTaskCloset : PuzzleManager
{
    public dzGroupsList dzGroupsList;
    public GameObject clothes;
    public GameObject taskScreen;
    //[HideInInspector] public bool puzzleSolved = false;
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
                }
            }
            else
            {
                puzzleSolved = false;
                playAudioOnce = false;
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
