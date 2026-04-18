using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    public Color bubbleColor_On;
    bool onInteractiveArea = false;
    bool onDistractionArea = false;
    GameObject currentInteractiveObject;
    GameObject currentDistractionObject;
    //public Color bubbleColor_Off;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(onInteractiveArea)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(currentInteractiveObject != null)
                {
                    TaskManager taskMng = currentInteractiveObject.GetComponent<TaskManager>();
                    taskMng.openTaskUI();
                }
            }
        }
        else if (onDistractionArea)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentDistractionObject != null)
                {
                    DistractionsManager distractionMng = currentDistractionObject.GetComponent<DistractionsManager>();
                    distractionMng.openTaskUI();
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
            onInteractiveArea = true;
            currentInteractiveObject = collision.gameObject;
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Distraction Objects"))
        {
            Transform bubble = collision.transform.Find("Bubble");
            bubble.GetComponent<Renderer>().material.color = bubbleColor_On;
            onDistractionArea = true;
            currentDistractionObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactive Objects"))
        {
            Transform bubble = collision.transform.Find("Bubble");
            bubble.GetComponent<Renderer>().material.color = Color.white;
            onInteractiveArea = false;
            currentInteractiveObject = null;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Distraction Objects"))
        {
            Transform bubble = collision.transform.Find("Bubble");
            bubble.GetComponent<Renderer>().material.color = Color.white;
            onDistractionArea = false;
            currentDistractionObject = null;
        }
    }

    public void taskCompleted()
    {
        onInteractiveArea = false;
        currentInteractiveObject = null;
    }
}
