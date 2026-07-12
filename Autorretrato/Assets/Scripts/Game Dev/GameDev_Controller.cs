using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDev_Controller : PuzzleManager
{
    public List<FurnitureToPlace> furniturePairs = new List<FurnitureToPlace>();
    bool playAudioOnce = false;
    public GameObject taskUI;
    
    void Update()
    {
        if(taskUI.activeInHierarchy)
        {
            if (checkFurnitureInPlace())
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

    bool checkFurnitureInPlace()
    {
        foreach (FurnitureToPlace FtP in furniturePairs)
        {
            DraggableObject dO = FtP.draggableObject.GetComponent<DraggableObject>();
            if (dO.target != FtP.dropZone.gameObject)
            {
                return false;
            }
        }

        return true;
    }
}
