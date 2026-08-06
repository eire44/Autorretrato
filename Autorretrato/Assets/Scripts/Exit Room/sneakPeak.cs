using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sneakPeak : MonoBehaviour
{
    public Transform cameraSpot;

    [HideInInspector] public bool looking = false;
    
    public void lookOutTheWindow()
    {
        looking = !looking;

        if(looking)
        {
            Camera.main.transform.position = cameraSpot.position;
            Time.timeScale = 0f;
        }
        else
        {
            Camera.main.transform.position = new Vector3 (0, 0, -10);
            Time.timeScale = 1f;
        }
    }
}
