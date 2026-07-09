using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(DraggableObject))]
public class Piece_Controller : MonoBehaviour
{
    public GameObject DropZones;
    DraggableObject draggableObject;
    // Start is called before the first frame update
    void Start()
    {
        draggableObject = GetComponent<DraggableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (draggableObject.dragging)
        {
            DropZones.SetActive(true);
        }else
        {
            DropZones.SetActive(false);
        }
    }
}
