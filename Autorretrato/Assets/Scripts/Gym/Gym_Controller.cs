using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gym_Controller : PuzzleManager
{
    float kilosRequired = 10f;
    float[] possibleWeights = { 2.5f, 5f, 7.5f, 10f };
    public TMP_Text weightText;
    public List<DropZone> leftDisks = new List<DropZone>();
    public List<DropZone> rightDisks = new List<DropZone>();
    public GameObject taskScreen;
    bool playAudioOnce = false;

    List<DropZone> leftDisks_Spawned = new List<DropZone>();
    List<DropZone> rightDisks_Spawned = new List<DropZone>();

    // Start is called before the first frame update
    void Start()
    {
        kilosRequired = possibleWeights[Random.Range(0, possibleWeights.Length)];
        weightText.text = "I need a " + kilosRequired + "-kilo dumbbell";

        generarDropZones();
    }

    void generarDropZones()
    {
        int dropZonesAmount = 5;

        if (kilosRequired == 2.5f)
        {
            dropZonesAmount = 2;
        }
        else if (kilosRequired == 5f)
        {
            dropZonesAmount = 3;
        }
        else if (kilosRequired == 7.5f)
        {
            dropZonesAmount = 4;
        }

        for (int i = 0; i < dropZonesAmount; i++) //el ultimo tamaño 2
        {
            leftDisks[i].gameObject.SetActive(true);
            rightDisks[i].gameObject.SetActive(true);

            if(i == dropZonesAmount - 1)
            {
                leftDisks[i].gameObject.transform.localScale = new Vector3(leftDisks[i].gameObject.transform.localScale.x, 2f, leftDisks[i].gameObject.transform.localScale.z);
                rightDisks[i].gameObject.transform.localScale = new Vector3(rightDisks[i].gameObject.transform.localScale.x, 2f, rightDisks[i].gameObject.transform.localScale.z);
            }

            leftDisks_Spawned.Add(leftDisks[i]);
            rightDisks_Spawned.Add(rightDisks[i]);
        }
    }

    void Update()
    {
        if (taskScreen.activeInHierarchy)
        {
            if (checkDumbbellsSetUp(leftDisks_Spawned) && checkDumbbellsSetUp(rightDisks_Spawned))
            {
                if (!playAudioOnce)
                {
                    playAudioOnce = true;
                    puzzleSolved = true;
                    activateFeedback(true, feedbackBubble);
                }
            }
            else
            {
                playAudioOnce = false;
                puzzleSolved = false;
                activateFeedback(false, feedbackBubble);
            }
        }
    }

    bool checkDumbbellsSetUp(List<DropZone> disksSide)
    {
        foreach (DropZone dz in disksSide)
        {
            if (dz.draggablePlaced)
            {
                if(dz == disksSide[disksSide.Count - 1])
                {
                    DraggableObject dO = dz.draggedObject.GetComponent<DraggableObject>();
                    if (dO != null)
                    {
                        if (dO.id != "2")
                        {
                            return false;
                        }
                    }
                }
            } 
            else
            {
                return false;
            }
        }

        return true;
    }

    //void checkWeight()
    //{
    //    int leftDisksWeight = 0;
    //    int rightDisksWeight = 0;

    //    foreach (DropZone dz in leftDisks)
    //    {
    //        if(dz.draggablePlaced)
    //        {
    //            DraggableObject dO = dz.draggedObject.GetComponent<DraggableObject>();
    //            if(dO != null)
    //            {
    //                if(dO.id == "1")
    //                {

    //                }
    //            }
    //        }
    //    }
    //}
}
