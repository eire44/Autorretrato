using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(DropZone))]
public class turnTable_MusicController : MonoBehaviour
{
    public TMP_Text txtSong;
    public AudioSource audioSource;
    DropZone dZ;
    bool playSong = true;
    bool addEnergy = true;
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
                if(addEnergy)
                {
                    addEnergy = false;
                    FindObjectOfType<GameManager>().AddEnergy();
                }
                
                if (playSong)
                {
                    playSong = false;
                    audioSource.PlayOneShot(song.clipToPlay);
                }
            }
            
        }
        else
        {
            txtSong.text = "No music playing";
            audioSource.Stop();
            playSong = true;
        }
    }
}
