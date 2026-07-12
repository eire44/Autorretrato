using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Puzzle : PuzzleManager
{
    public DraggableObject draggableObject;
    public GameObject correctDropZone;
    bool playAudioOnce = false;
    

    // Update is called once per frame
    void Update()
    {
        if (draggableObject.target != null)
        {
            DropZone dropZone = draggableObject.target.GetComponent<DropZone>();

            if (dropZone != null)
            {
                if (dropZone.gameObject == correctDropZone)
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
            else
            {
                playAudioOnce = false;
                puzzleSolved = false;
                activateFeedback(false, feedbackBubble);
            }
        }
    }
}
