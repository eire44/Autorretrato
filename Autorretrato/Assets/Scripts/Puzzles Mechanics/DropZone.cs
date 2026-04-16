using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string idCorrecto;
    [HideInInspector] public string idOriginal;
    [HideInInspector] public bool draggablePlaced = false;

    private void Start()
    {
        idOriginal = idCorrecto;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableObject piece = dropped.GetComponent<DraggableObject>();

        if(piece.id == idCorrecto || int.Parse(idCorrecto) == -1)
        {
            RectTransform pieceRect = piece.GetComponent<RectTransform>();
            RectTransform zoneRect = GetComponent<RectTransform>();

            pieceRect.SetParent(zoneRect);

            pieceRect.anchoredPosition = Vector2.zero;

            pieceRect.sizeDelta = zoneRect.sizeDelta;

            pieceRect.localScale = Vector3.one;

            draggablePlaced = true;
            piece.zone = this;
            piece.draggablePlaced = true;

            if (int.Parse(idCorrecto) == -1 && int.Parse(piece.id) != -1)
            {
                idCorrecto = piece.id;
            }
        }
    }
}
