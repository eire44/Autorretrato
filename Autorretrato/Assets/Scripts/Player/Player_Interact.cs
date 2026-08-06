using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player_Interact : MonoBehaviour
{
    public Color bubbleColor_On;
    bool onInteractiveArea = false;
    [HideInInspector] public bool onDistractionArea = false;
    bool onOuterViewArea = false;
    [HideInInspector] public bool onFinalDoorArea = false;
    GameObject currentInteractiveObject;
    GameObject currentDistractionObject;
    //public Color bubbleColor_Off;
    sneakPeak sneakPeak;
    Dialogs_Controller dialogs_Controller;

    private void Start()
    {
        sneakPeak = FindObjectOfType<sneakPeak>();
        dialogs_Controller = FindObjectOfType<Dialogs_Controller>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (onOuterViewArea)
            {
                sneakPeak.lookOutTheWindow();
            }
            else if (onFinalDoorArea)
            {
                Level_Manager.levelIndex = 0;
                //Time.timeScale = 0f;
                SceneManager.LoadScene("End Scene");
            }
            else if (onInteractiveArea)
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
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Outer Views"))
        {
            onOuterViewArea = true;
            onArea(Color.white, collision.transform, "There is such a nice view from this window. I could go there sometime, when I have time.");
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
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Outer Views"))
        {
            onOuterViewArea = false;
            onArea(Color.white, collision.transform, "...");
        }
    }

    public void taskCompleted()
    {
        onInteractiveArea = false;
        currentInteractiveObject = null;
    }
}
