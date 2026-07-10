using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(DraggableObject))]
public class Food_Controller : MonoBehaviour
{
    public string foodName;
    public bool drink = false;
    DraggableObject draggableObject;
    public TMP_Text txtFoodName;

    private void Start()
    {
        draggableObject = GetComponent<DraggableObject>();
    }

    private void Update()
    {
        if(draggableObject.dragging)
        {
            txtFoodName.text = foodName;
        }
    }
}
