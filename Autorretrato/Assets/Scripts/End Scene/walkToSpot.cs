using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkToSpot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 3f;
    [SerializeField] private Animator animator;

    private bool isMoving = false;
    [SerializeField] private GameObject pantallaFinal;

    private void Start()
    {
        Move();
    }

    public void Move()
    {
        isMoving = true;
        animator.SetBool("Arrived", false);
    }

    private void Update()
    {
        if (!isMoving || target == null)
            return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            transform.position = target.position;
            isMoving = false;

            animator.SetBool("Arrived", true);

            StartCoroutine(mostrarPantallaFinal());
        }
    }

    private IEnumerator mostrarPantallaFinal()
    {
        yield return new WaitForSeconds(2.5f);

        pantallaFinal.SetActive(true);
        Time.timeScale = 0f;
    }
}
