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
    HashSet<string> musicPlayed = new HashSet<string>();

    string songPlaying = "No music playing";
    bool playing = false;
    //turntable_playMusic song;
    private void Start()
    {
        dZ = GetComponent<DropZone>();
        txtSong.text = songPlaying;
        //song = dZ.draggedObject.GetComponent<turntable_playMusic>();
    }

    private void Update()
    {
        distractionTask();
    }

    public void distractionTask()
    {
        if (dZ.draggablePlaced)
        {
            turntable_playMusic song = dZ.draggedObject.GetComponent<turntable_playMusic>();
            if (song != null)
            {
                

                
                    if (!musicPlayed.Contains(song.songName))
                    {
                        FindObjectOfType<GameManager>().AddEnergy();
                        FindObjectOfType<DistractionsManager>().activateFeedback(true);
                    }
                

                if (playSong)
                {
                    playSong = false;
                    songPlaying = song.songName;
                    txtSong.text = songPlaying;
                    audioSource.PlayOneShot(song.clipToPlay);
                    musicPlayed.Add(song.songName);
                    FindObjectOfType<options_Controlller>().lowerMusicForTurntable(0.25f);
                    playing = true;
                }
            }

        }
        else
        {
            txtSong.text = "No music playing";
            audioSource.Stop();
            if(playing)
            {
                FindObjectOfType<options_Controlller>().lowerMusicForTurntable(FindObjectOfType<options_Controlller>().previousMusicVolume);
                playing = false;
            }
            FindObjectOfType<DistractionsManager>().activateFeedback(false);
            playSong = true;
        }
    }
}
