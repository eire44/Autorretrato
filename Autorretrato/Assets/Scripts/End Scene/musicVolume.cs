using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class musicVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    void Start()
    {
        float music = PlayerPrefs.GetFloat("Music_Volume", 1f);

        music = Mathf.Clamp(music, 0.0001f, 1f);

        float musicCurved = music * music;

        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicCurved) * 20);
    }
}
