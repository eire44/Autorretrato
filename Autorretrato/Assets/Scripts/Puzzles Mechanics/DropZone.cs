using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string idCorrecto;
    [HideInInspector] public bool draggablePlaced = false;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableObject piece = dropped.GetComponent<DraggableObject>();

        if(piece.id == idCorrecto)
        {
            RectTransform pieceRect = piece.GetComponent<RectTransform>();
            RectTransform zoneRect = GetComponent<RectTransform>();

            pieceRect.SetParent(zoneRect);

            pieceRect.anchoredPosition = Vector2.zero;

            pieceRect.sizeDelta = zoneRect.sizeDelta;

            pieceRect.localScale = Vector3.one;

            draggablePlaced = true;
            piece.zone = this;
        }
    }
}
