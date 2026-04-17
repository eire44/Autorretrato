using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(DropZone))]
public class turnTable_MusicController : MonoBehaviour
{
    public TMP_Text txtSong;
    //public AudioClip clipToPlay;
    DropZone dZ;

    private void Start()
    {
        dZ = GetComponent<DropZone>();
    }

    private void Update()
    {
        if(dZ.draggablePlaced)
        {
            turntable_playMusic song = dZ.draggedObject.GetComponent<turntable_playMusic>();
            if(song != null)
            {
                txtSong.text = "Playing: " + song.songName;
            }
            
        }
        else
        {
            txtSong.text = "No music playing";
        }
    }
}
