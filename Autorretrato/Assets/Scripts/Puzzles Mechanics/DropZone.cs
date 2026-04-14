using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string idCorrecto;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableObject piece = dropped.GetComponent<DraggableObject>();

        RectTransform pieceRect = piece.GetComponent<RectTransform>();
        RectTransform zoneRect = GetComponent<RectTransform>();

        //piece.parentAfterDrag = transform;

        // Cambiar padre (MUY IMPORTANTE)
        pieceRect.SetParent(zoneRect);

        // Centrar
        pieceRect.anchoredPosition = Vector2.zero;

        // Igualar tamaño
        pieceRect.sizeDelta = zoneRect.sizeDelta;

        // Resetear escala
        pieceRect.localScale = Vector3.one;
    }
}
