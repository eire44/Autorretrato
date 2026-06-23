using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragIncense : DraggableObject
{
    public Transform incenseSet;
    public override void OnBeginDrag(PointerEventData eventData)
    {
        draggableAudio.Play();
        
        transform.SetParent(incenseSet);

        transform.SetAsLastSibling();
        image.raycastTarget = false;
        foreach (var graphic in GetComponentsInChildren<UnityEngine.UI.Graphic>())
        {
            graphic.raycastTarget = false;
        }

        if (zone != null)
        {
            zone.draggablePlaced = false;
            draggablePlaced = false;
            zone.idCorrecto = zone.idOriginal;
            zone = null;
        }
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        foreach (var graphic in GetComponentsInChildren<UnityEngine.UI.Graphic>())
        {
            graphic.raycastTarget = true;
        }
    }
}
