using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DraggableObject))]
public class LightIncense : MonoBehaviour
{
    DraggableObject draggableObject;
    bool flag = true;
    public GameObject smoke;

    private void Start()
    {
        draggableObject = GetComponent<DraggableObject>();
    }

    private void Update()
    {
        if(flag)
        {
            if (draggableObject.draggablePlaced)
            {
                flag = false;
                smoke.SetActive(true);
            }
        }
    }
}
