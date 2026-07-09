using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Agenda_Controller))]
public class check_AgendaFilled : PuzzleManager
{
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
                    activateFeedback(true, feedbackBubble);
                }
            }
            else
            {
                playAudioOnce = false;
                activateFeedback(false, feedbackBubble);
            }
        }
    }

    public override bool checkIfTaskCompleted(GameObject taskUI)
    {
        Agenda_Controller agenda_Controller = GetComponent<Agenda_Controller>();

        for (int i = 0; i < agenda_Controller.tasksTxts.Length; i++)
        {
            if (!agenda_Controller.dropZones[i].draggablePlaced)
            {
                return false;
            }
        }

        //foreach (DropZone dZone in agenda_Controller.dropZones)
        //{
        //    if (!dZone.draggablePlaced)
        //    {
        //        return false;
        //    }
        //}

        return true;
    }
}
