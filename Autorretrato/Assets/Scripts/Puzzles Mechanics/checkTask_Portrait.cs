using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTask_Portrait : PuzzleManager
{
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
                    if (draggable.id + 1 != dropZone.idCorrecto || int.Parse(dropZone.idCorrecto) == -1)
                    {
                        return false;
                    }
                }
            }
        }
        
        return true;
    }
}
