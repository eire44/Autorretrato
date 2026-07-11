using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Agenda_Controller))]
public class check_AgendaFilled : PuzzleManager
{
    public GameObject taskScreen;
    bool playAudioOnce = false;
    Agenda_Controller agenda_Controller;
    private void Start()
    {
        agenda_Controller = GetComponent<Agenda_Controller>();
    }

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
        for (int i = 0; i < agenda_Controller.tasksTxts.Length; i++)
        {
            if (!agenda_Controller.dropZones[i].draggablePlaced)
            {
                Debug.Log("NO LLENO");
                return false;
            }
        } //se cumple si están TODAS las dropzones llenas

        //foreach (DropZone dZone in agenda_Controller.dropZones)
        //{
        //    if (!dZone.draggablePlaced)
        //    {
        //        return false;
        //    }
        //}

        Debug.Log("LLENO");
        return true;
    }
}
