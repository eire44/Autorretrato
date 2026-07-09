using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public AudioSource taskDone;
    public GameObject feedbackBubble;
    [HideInInspector] public virtual bool puzzleSolved { get; set; } = false;

    public virtual bool checkIfTaskCompleted(GameObject taskUI)
    {
        foreach (Transform UIitem in taskUI.transform)
        {
            DropZone dropZone = UIitem.GetComponent<DropZone>();
            if (dropZone != null)
            {
                if (!dropZone.draggablePlaced)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void activateFeedback(bool puzzleComplete, GameObject feedbackBubble)
    {
        if (puzzleComplete)
        {
            taskDone.Play();
        }

        feedbackBubble.SetActive(puzzleComplete);
    }
}
