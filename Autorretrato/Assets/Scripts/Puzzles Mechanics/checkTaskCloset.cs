using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class checkTaskCloset : PuzzleManager
{
    public dzGroupsList dzGroupsList;
    public override bool checkIfTaskCompleted(GameObject taskUI)
    {
        foreach (DropZoneGroups dzG in dzGroupsList.dzGroups)
        {
            int groupID = -1;
            bool takeOneID = true;
            foreach (DropZone dz in dzG.dzGroups)
            {
                if(dz.draggablePlaced)
                {
                    if(takeOneID)
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

        return true;
    }
}
