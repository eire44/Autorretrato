using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Distractions_UI))]
public class Merienda_Puzzle_Controller : MonoBehaviour
{
    public List<DropZone> platesList = new List<DropZone>();
    public List<DraggableObject> foodList = new List<DraggableObject>();

    public GameObject Bubble;
    public Player_Interact player_Interact;
    public GameObject plates;

    Distractions_UI distractions_UI;
    void Start()
    {
        distractions_UI = GetComponent<Distractions_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!distractions_UI.puzzleSolved)
        {
            if(checkIfMeriendaSet())
            {
                distractions_UI.puzzleSolved = true;
                Bubble.SetActive(false);
                player_Interact.onDistractionArea = false;
                plates.layer = LayerMask.NameToLayer("Default");
                foreach (DropZone dz in platesList)
                {
                    dz.gameObject.SetActive(false);
                }
                foreach (DraggableObject food in foodList)
                {
                    food.enabled = false;
                }

                if (!distractions_UI.distractionToTask)
                {
                    FindObjectOfType<GameManager>().AddEnergy();
                    FindObjectOfType<DistractionsManager>().activateFeedback(true);
                }
            }
        }
    }

    //void chooseFood()
    //{
    //    while (selectedFood == "" || selectedDrink == "")
    //    {
    //        int selectedFood = Random.Range(0, foodList.Count);
    //        if (foodList[selectedFood].drink && selectedDrink == "")
    //        {
    //            selectedDrink = foodList[selectedFood].foodName;
    //        }
    //    }
    //    foreach (Food_Controller food in foodList)
    //    {
            
    //    }

    //    distractions_UI.txtDialog = "I'd like to have a coffee and a croissant.";
    //}

    bool checkIfMeriendaSet()
    {
        bool drinkPlaced = false;
        bool foodPlaced = false;
        foreach (DropZone plate in platesList)
        {
            if (plate.draggablePlaced)
            {
                if (plate.draggedObject.GetComponent<Food_Controller>().drink)
                {
                    drinkPlaced = true;
                } else
                {
                    foodPlaced = true;
                }
            } 
            else
            {
                return false;
            }        
        }

        if (drinkPlaced && foodPlaced)
        {
            distractions_UI.puzzleSolved = true;
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
