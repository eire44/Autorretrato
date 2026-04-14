using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer_Controller : MonoBehaviour
{
    public float tiempoRestante = 60f;
    public TextMeshProUGUI textoTiempo;

    bool flagEndGame = true;
    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarUI();
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
    }

    void ActualizarUI()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);

        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void FinDelTiempo()
    {
        Debug.Log("Tiempo terminado");
        FindObjectOfType<UI_Controller>().showEndGameScreen();
    }
}
