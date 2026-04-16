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
                    Debug.Log(draggable.name + " not placed");
                    return false;
                }
                else
                {
                    if(dropZone.idCorrecto != -1)
                    {
                        Debug.Log(draggable.name + " is not -1");
                        if (int.Parse(draggable.id) + 1 != dropZone.idCorrecto)
                        {
                            //Debug.Log(draggable.name + " wrong id");
                            //Debug.Log((draggable.id + 1) + " ");
                            return false;
                        }
                    }
                    
                }
            }
        }
        
        return true;
    }
}
