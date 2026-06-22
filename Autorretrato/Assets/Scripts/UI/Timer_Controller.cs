using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer_Controller : MonoBehaviour
{
    public float tiempoRestante = 60f;
    public TextMeshProUGUI textoTiempo;
    float tiempoTotal;
    [HideInInspector] public bool flagEndGame = true;
    public AudioSource clockSound;
    bool playClock = true;

    UI_Controller uiController;

    private void Start()
    {
        tiempoTotal = tiempoRestante;
        uiController = FindObjectOfType<UI_Controller>();
    }
    void Update()
    {
        if (tiempoRestante > 0)
        {
            if(!uiController.volumeScreen.activeInHierarchy)
            {
                tiempoRestante -= Time.unscaledDeltaTime;
                ActualizarUI();
            }
        }
        else
        {
            if(flagEndGame)
            {
                flagEndGame = false;
                tiempoRestante = 0;
                ActualizarUI();
                FinDelTiempo();
            }
        }

        if(tiempoRestante > tiempoTotal / 4)
        {
            textoTiempo.color = Color.black;
            playClock = true;
        }
        else
        {
            textoTiempo.color = Color.red;
            if(playClock)
            {
                playClock = false;
                clockSound.Play();
            }
            
        }
    }

    void ActualizarUI()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);

        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void FinDelTiempo()
    {
        uiController.showEndGameScreen();
    }
}
