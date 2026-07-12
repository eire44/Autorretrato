using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Interact : MonoBehaviour
{
    public Color bubbleColor_On;
    bool onInteractiveArea = false;
    [HideInInspector] public bool onDistractionArea = false;
    GameObject currentInteractiveObject;
    GameObject currentDistractionObject;
    //public Color bubbleColor_Off;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (onInteractiveArea)
            {
                if (currentInteractiveObject != null)
                {
                    TaskManager taskMng = currentInteractiveObject.GetComponent<TaskManager>();
                    taskMng.openTaskUI();
                }
            }
            else if (onDistractionArea)
            {
                if (currentDistractionObject != null)
                {
                    Distractions_UI distractionMng = currentDistractionObject.GetComponent<Distractions_UI>();
                    distractionMng.openTaskUI();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Interactive Objects"))
        {
            TaskManager tM = collision.gameObject.GetComponent<TaskManager>();
            if (tM != null)
            {
                onArea(bubbleColor_On, collision.transform, tM.txtDialog);
            }
            
            onInteractiveArea = true;
            currentInteractiveObject = collision.gameObject;
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Distraction Objects"))
        {
            Distractions_UI dUI = collision.gameObject.GetComponent<Distractions_UI>();
            if(dUI != null)
            {
                onArea(bubbleColor_On, collision.transform, dUI.txtDialog);
            }
            
            onDistractionArea = true;
            currentDistractionObject = collision.gameObject;
        }
    }
    
    void onArea(Color color, Transform collision, string dialogText)
    {
        Transform bubble = collision.Find("Bubble");

        if(bubble != null)
        {
            bubble.GetComponent<Renderer>().material.color = color;
        }

        Transform disrtactionBubble = collision.Find("DistractionBubble");

        if (disrtactionBubble != null)
        {
            disrtactionBubble.GetComponent<Renderer>().material.color = color;
        }

        Dialogs_Controller dialogs_Controller = FindObjectOfType<Dialogs_Controller>();

        if (dialogs_Controller != null)
        {
            dialogs_Controller.changeDialogTxt(dialogText);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactive Objects"))
        {
            onArea(Color.white, collision.transform, "...");
            onInteractiveArea = false;
            currentInteractiveObject = null;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Distraction Objects"))
        {
            onArea(Color.white, collision.transform, "...");
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
