using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Distractions_UI))]
public class Backpack_Puzzle_Controller : MonoBehaviour
{
    public List<GameObject> stuff = new List<GameObject>();
    bool puzzleSolved = false;

    public GameObject Bubble;
    public Player_Interact player_Interact;
    public GameObject cellphone;
    public GameObject distractionUI;

    Distractions_UI distractions_UI;
    void Start()
    {
        distractions_UI = GetComponent<Distractions_UI>();
    }


    void Update()
    {
        if (distractionUI.activeInHierarchy)
        {
            if (!distractions_UI.puzzleSolved)
            {
                if (checkIfAllStuffOnBackpack())
                {
                    distractions_UI.puzzleSolved = true;
                    Bubble.SetActive(false);
                    player_Interact.onDistractionArea = false;
                    cellphone.layer = LayerMask.NameToLayer("Default");

                    if(!distractions_UI.distractionToTask)
                    {
                        FindObjectOfType<GameManager>().AddEnergy();
                        FindObjectOfType<DistractionsManager>().activateFeedback(true);
                    }
                }
            }
        }
    }

    bool checkIfAllStuffOnBackpack()
    {
        foreach (GameObject thing in stuff)
        {
            if (thing.activeInHierarchy)
            {
                return false;
            }
        }

        return true;
    }
}
