using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class options_Controller : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public bool checkAnswer = false;
    public bool correctAnswer = false;
    public GameObject greenCheck;

    public void OnPointerClick(PointerEventData eventData)
    {
        checkAnswer = !checkAnswer;

        if(checkAnswer)
        {
            //sonido check
            greenCheck.SetActive(true);
        }
        else
        {
            greenCheck.SetActive(false);
        }
    }
}
