using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Agenda_Controller))]
public class check_AgendaFilled : PuzzleManager
{
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
