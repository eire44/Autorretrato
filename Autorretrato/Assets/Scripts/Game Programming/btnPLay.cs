using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class btnPLay : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public bool playing = false;
    public Ball_Controller ball_Controller;
    public Game_Programming_Conttroller game_Programming_Controller;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(game_Programming_Controller.checkIfValuesAssigned())
        {
            Debug.Log("values assigned");
            ball_Controller.resetBallPosition();
            playing = true;
            game_Programming_Controller.checkWinCondition();
        }
    }
}
