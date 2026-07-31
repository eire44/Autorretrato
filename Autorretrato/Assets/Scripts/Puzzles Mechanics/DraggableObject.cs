using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string id;
    [HideInInspector] public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public DropZone zone;
    RectTransform rectTransform;
    [HideInInspector] public Vector2 originalSize;
    [HideInInspector] public Vector3 originalScale;
    [HideInInspector] public bool draggablePlaced = false;
    public AudioSource draggableAudio;
    [HideInInspector] public bool dragging = false;
    [HideInInspector] public GameObject target;

    void Awake()
    {
        image = GetComponent<Image>();
        
        rectTransform = GetComponent<RectTransform>();

        originalSize = rectTransform.sizeDelta;
        originalScale = rectTransform.localScale;
        
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        dragging = true;
        draggableAudio.Play();
        parentAfterDrag = transform.parent;
        //transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        foreach (var graphic in GetComponentsInChildren<UnityEngine.UI.Graphic>())
        {
            graphic.raycastTarget = false;
        }

        rectTransform.sizeDelta = originalSize;
        rectTransform.localScale = originalScale;

        if(zone != null)
        {
            zone.draggablePlaced = false;
            draggablePlaced = false;
            zone.idCorrecto = zone.idOriginal;
            zone = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
        target = eventData.pointerCurrentRaycast.gameObject;

        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

        foreach (var graphic in GetComponentsInChildren<UnityEngine.UI.Graphic>())
        {
            graphic.raycastTarget = true;
        }
    }
}
