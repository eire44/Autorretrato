using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class shiningObjects : MonoBehaviour
{
    [SerializeField] private Light2D brillo_Ventana;
    [SerializeField] private bool isDoor;
    Level_Manager level_Manager;
    Player_Interact player_Interact;

    private void Start()
    {
        level_Manager = FindObjectOfType<Level_Manager>();
        player_Interact = FindObjectOfType<Player_Interact>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FadeIn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        if(isDoor)
        {
            if(Level_Manager.levelIndex + 1 >= level_Manager.levels.Count)
            {
                StartCoroutine(FadeInCoroutine());
                player_Interact.onFinalDoorArea = true;
            }
        } else
        {
            StartCoroutine(FadeInCoroutine());
        }
    }

    public void FadeOut()
    {
        if (isDoor)
        {
            if (Level_Manager.levelIndex + 1 >= level_Manager.levels.Count)
            {
                StartCoroutine(FadeOutCoroutine());
                player_Interact.onFinalDoorArea = false;
            }
        }
        else
        {
            StartCoroutine(FadeOutCoroutine());
        }
    }

    private IEnumerator FadeInCoroutine()
    {
        float duration = 0.5f;
        float elapsed = 0f;

        //brillo_Ventana.intensity = 0f;
        float initial_Intensity = brillo_Ventana.intensity;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            brillo_Ventana.intensity = Mathf.Lerp(initial_Intensity, 1f, elapsed / duration);

            yield return null;
        }

        brillo_Ventana.intensity = 1f;
    }

    private IEnumerator FadeOutCoroutine()
    {
        float duration = 0.5f;
        float elapsed = 0f;

        //brillo_Ventana.intensity = 0f;
        float initial_Intensity = brillo_Ventana.intensity;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            brillo_Ventana.intensity = Mathf.Lerp(initial_Intensity, 0f, elapsed / duration);

            yield return null;
        }

        brillo_Ventana.intensity = 0f;
    }
}
