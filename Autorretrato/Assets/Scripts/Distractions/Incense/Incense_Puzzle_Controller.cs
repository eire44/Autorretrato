using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Distractions_UI))]
public class Incense_Puzzle_Controller : MonoBehaviour
{
    public DragIncense incense;
    public GameObject smoke;
    bool puzzleSolved = false;
    public GameObject Bubble;
    public GameObject SahumerioSet;
    public Player_Interact player_Interact;
    public List<DropZone> dropZones = new List<DropZone>();
    Distractions_UI distractions_UI;
    void Start()
    {
        distractions_UI = GetComponent<Distractions_UI>();
    }


    void Update()
    {
        if (!distractions_UI.puzzleSolved)
        {
            checkIncensePlacedandLit();
        }
    }

    void checkIncensePlacedandLit()
    {
        if(smoke.activeInHierarchy && incense.draggablePlaced)
        {
            distractions_UI.puzzleSolved = true;
            incense.enabled = false;
            Bubble.SetActive(false);
            player_Interact.onDistractionArea = false;
            SahumerioSet.layer = LayerMask.NameToLayer("Default");
            foreach (DropZone dz in dropZones)
            {
                dz.gameObject.SetActive(false);
            }

            if (!distractions_UI.distractionToTask)
            {
                FindObjectOfType<GameManager>().AddEnergy();
                FindObjectOfType<DistractionsManager>().activateFeedback(true);
            }
        }
    }
}
