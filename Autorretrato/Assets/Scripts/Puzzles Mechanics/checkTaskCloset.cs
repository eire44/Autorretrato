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
            string groupID = "";
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
        //foreach (Transform UIitem in taskUI.transform)
        //{
        //    DropZone dropZone = UIitem.GetComponent<DropZone>();
        //    if (dropZone != null)
        //    {
        //        string id = dropZone.idCorrecto;
        //        DropZoneGroups dzGroup = dropZone.GetComponent<DropZoneGroups>();
        //        if (dzGroup != null)
        //        {
        //            foreach (DropZone dzG in dzGroup.dzGroups)
        //            {
        //                if(dzG.draggablePlaced)
        //                {
        //                    if (dzG.idCorrecto != id)
        //                    {
        //                        return false;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //return true;
    }
}
