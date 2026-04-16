using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTask_ReadBook : PuzzleManager
{
    int orderId = 0;
    public override bool checkIfTaskCompleted(GameObject taskUI)
    {
        foreach (Transform UIitem in taskUI.transform)
        {
            DropZone dropZone = UIitem.GetComponent<DropZone>();
            if (dropZone != null)
            {
                if (!dropZone.draggablePlaced)
                {
                    return false;
                }
                else
                {
                    if(dropZone.idCorrecto == orderId.ToString())
                    {
                        orderId++;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}
