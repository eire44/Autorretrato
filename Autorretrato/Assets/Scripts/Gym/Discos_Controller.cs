using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(DraggableObject))]
public class Discos_Controller : MonoBehaviour, IPointerClickHandler
{
    Image image;
    public Sprite discoLateral;
    DraggableObject draggableObject;
    RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        draggableObject = GetComponent<DraggableObject>();
        draggableObject.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(image.sprite != discoLateral)
        {
            image.sprite = discoLateral;

            Vector3 newScale = new Vector3(1.7f, rectTransform.localScale.y, rectTransform.localScale.z);
            rectTransform.localScale = newScale;
            draggableObject.originalScale = newScale;

            draggableObject.enabled = true;
        }
    }
}
