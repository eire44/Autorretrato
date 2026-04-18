using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public int idCorrecto;
    [HideInInspector] public int idOriginal;
    [HideInInspector] public bool draggablePlaced = false;
    [HideInInspector] public GameObject draggedObject;
    public AudioSource droppedAudio;
    private void Start()
    {
        idOriginal = idCorrecto;
    }

    public void OnDrop(PointerEventData eventData)
    {
        droppedAudio.Play();
        GameObject dropped = eventData.pointerDrag;
        DraggableObject piece = dropped.GetComponent<DraggableObject>();

        if(int.Parse(piece.id) == idCorrecto || idCorrecto == -1)
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
            draggedObject = piece.gameObject;

            if (idCorrecto == -1 && int.Parse(piece.id) != -1)
            {
                idCorrecto = int.Parse(piece.id);
            }
        }
    }
}
