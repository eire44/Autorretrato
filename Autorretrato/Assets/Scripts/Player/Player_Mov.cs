using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    public float velocidad = 5f;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float velocidadY = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        bool moving = velocidadX != 0 || velocidadY != 0;
        animator.SetBool("Moving", moving);

        Vector3 posicion = transform.position;
        posicion += new Vector3(velocidadX, velocidadY, 0);

        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, posicion.z));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, posicion.z));

        posicion.x = Mathf.Clamp(posicion.x, min.x, max.x);
        posicion.y = Mathf.Clamp(posicion.y, min.y, max.y);

        transform.position = posicion;
    }
}
