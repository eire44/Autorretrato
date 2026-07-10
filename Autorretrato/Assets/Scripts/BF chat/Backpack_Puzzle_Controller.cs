using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack_Puzzle_Controller : MonoBehaviour
{
    public List<GameObject> stuff = new List<GameObject>();
    bool puzzleSolved = false;

    public GameObject Bubble;
    public Player_Interact player_Interact;
    public GameObject cellphone;
    public GameObject distractionUI;

    void Update()
    {
        if (distractionUI.activeInHierarchy)
        {
            if (!puzzleSolved)
            {
                if (checkIfAllStuffOnBackpack())
                {
                    puzzleSolved = true;
                    Bubble.SetActive(false);
                    player_Interact.onDistractionArea = false;
                    FindObjectOfType<GameManager>().AddEnergy();
                    cellphone.layer = LayerMask.NameToLayer("Default");
                    FindObjectOfType<DistractionsManager>().activateFeedback(true);
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
