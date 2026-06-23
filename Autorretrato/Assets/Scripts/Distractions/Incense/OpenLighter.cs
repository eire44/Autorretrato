using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenLighter : MonoBehaviour, IPointerClickHandler
{
    public GameObject encendedorAbierto;
    public void OnPointerClick(PointerEventData eventData)
    {
        encendedorAbierto.SetActive(true);
        encendedorAbierto.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
