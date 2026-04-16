using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stack_DraggableObjects : MonoBehaviour
{
    DropZone dZ;
    DraggableObject dO;
    // Start is called before the first frame update
    void Start()
    {
        dZ = GetComponent<DropZone>();
        dO = GetComponent<DraggableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dZ != null)
        {
            if(dO.draggablePlaced)
            {
                dZ.enabled = true;
            }
            else
            {
                dZ.enabled = false;
            }
        }
    }
}
