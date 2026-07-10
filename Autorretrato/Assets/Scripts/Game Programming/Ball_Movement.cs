using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball_Controller))]
public class Ball_Movement : MonoBehaviour
{
    public float speed = 200f;

    public int x = 0; //direction along the X axis
    public int y = 0; //direction along the Y axis

    RectTransform rectTransform;

    Ball_Controller ball_Controller;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ball_Controller = GetComponent<Ball_Controller>();
    }

    void Update()
    {
        if (!ball_Controller.puzzleSolved)
        {
            Vector2 direction = new Vector2(x, y);
            rectTransform.anchoredPosition += direction * speed * Time.unscaledDeltaTime;
        }

    }
}
