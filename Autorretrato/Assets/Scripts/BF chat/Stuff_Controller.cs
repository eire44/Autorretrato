using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DraggableObject))]
public class Stuff_Controller : MonoBehaviour
{
    DraggableObject draggableObject;
    RectTransform rectTransform;
    public RectTransform Backpack_RectTransform;
    public GameObject distractionUI;
    public DropZone dz;
    // Start is called before the first frame update
    void Start()
    {
        draggableObject = GetComponent<DraggableObject>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!draggableObject.dragging && distractionUI.activeInHierarchy)
        {
            if (draggableObject.target == dz.gameObject)
            {
                //sonidito
                gameObject.SetActive(false);
            }
        }
    }
}
