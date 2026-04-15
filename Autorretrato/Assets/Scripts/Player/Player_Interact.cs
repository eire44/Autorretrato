using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    public Color bubbleColor_On;
    bool onArea = false;
    GameObject currentInteractiveObject;
    //public Color bubbleColor_Off;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(onArea)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(currentInteractiveObject != null)
                {
                    TaskManager taskMng = currentInteractiveObject.GetComponent<TaskManager>(); //condVic:PuzzMan
                    taskMng.openTaskUI();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Interactive Objects"))
        {
            Transform bubble = collision.transform.Find("Bubble");
            bubble.GetComponent<Renderer>().material.color = bubbleColor_On;
            onArea = true;
            currentInteractiveObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactive Objects"))
        {
            Transform bubble = collision.transform.Find("Bubble");
            bubble.GetComponent<Renderer>().material.color = Color.white;
            onArea = false;
            currentInteractiveObject = null;
        }
    }

    public void taskCompleted()
    {
        onArea = false;
        currentInteractiveObject = null;
    }
}
