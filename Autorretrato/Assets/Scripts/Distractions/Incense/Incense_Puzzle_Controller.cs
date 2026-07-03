using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incense_Puzzle_Controller : MonoBehaviour
{
    public DragIncense incense;
    public GameObject smoke;
    bool puzzleSolved = false;
    public GameObject Bubble;
    public GameObject SahumerioSet;
    public Player_Interact player_Interact;
    public List<DropZone> dropZones = new List<DropZone>();

    void Update()
    {
        if (!puzzleSolved)
        {
            checkIncensePlacedandLit();
        }
    }

    void checkIncensePlacedandLit()
    {
        if(smoke.activeInHierarchy && incense.draggablePlaced)
        {
            puzzleSolved = true;
            incense.enabled = false;
            Bubble.SetActive(false);
            player_Interact.onDistractionArea = false;
            FindObjectOfType<GameManager>().AddEnergy();
            SahumerioSet.layer = LayerMask.NameToLayer("Default");
            foreach (DropZone dz in dropZones)
            {
                dz.gameObject.SetActive(false);
            }
            FindObjectOfType<DistractionsManager>().activateFeedback(true);
        }
    }
}
