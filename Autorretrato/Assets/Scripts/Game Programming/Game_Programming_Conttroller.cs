using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Programming_Conttroller : PuzzleManager
{
    public GameObject txtErrorMessage;
    public List<DraggableObject> numberOptions = new List<DraggableObject>();

    public Ball_Movement ball_Movement;

    public DropZone dzX;
    public DropZone dzY;
    bool playAudioOnce = false;
    
    public void puzzleStatus(bool complete)
    {
        if (!playAudioOnce)
        {
            playAudioOnce = complete;
            activateFeedback(complete, feedbackBubble);
        }
    }

    public bool checkIfValuesAssigned()
    {
        int placedAmount = 0;
        foreach (DraggableObject o in numberOptions)
        {
            if(o.draggablePlaced)
            {
                placedAmount++;

                if (o.zone == dzX)
                {
                    ball_Movement.x = int.Parse(o.id);
                } else if (o.zone == dzY)
                {
                    ball_Movement.y = int.Parse(o.id);
                }
            }
        }

        if (placedAmount == 2)
        {
            txtErrorMessage.SetActive(false);
            return true;
        } else
        {
            txtErrorMessage.SetActive(true);
            return false;
        }
    }

    public void checkWinCondition()
    {
        if(ball_Movement.x == 1 && ball_Movement.y == 0)
        {
            puzzleStatus(true);
        }
        else
        {
            puzzleStatus(false);
        }
    }
}
