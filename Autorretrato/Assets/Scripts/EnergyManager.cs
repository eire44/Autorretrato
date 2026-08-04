using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnergyManager : MonoBehaviour
{
    public AudioSource music;
    public Player_Mov playerMovement;
    public Tilemap tilemap;

    [Header("Movement")]
    public float minSpeed = 4f;
    public float maxSpeed = 6f;

    [Header("Music")]
    public float minPitch = 0.9f;
    public float maxPitch = 1f;

    [Header("Tilemap")]
    public Color lowEnergyColor;
    //A0B8D7 o 819BBC

    public void UpdateAesthetics(float energy)
    {
        Debug.Log(energy);
        music.pitch = Mathf.Lerp(minPitch, maxPitch, energy);
        playerMovement.velocidad = Mathf.Lerp(minSpeed, maxSpeed, energy);
        tilemap.color = Color.Lerp(lowEnergyColor, Color.white, energy);
    }
}
