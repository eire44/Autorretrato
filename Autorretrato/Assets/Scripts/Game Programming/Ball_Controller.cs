using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball_Movement))]
public class Ball_Controller : MonoBehaviour
{
    RectTransform ballTransform;
    public RectTransform grassTransform;
    public RectTransform holeTransform;

    public btnPLay btnPlay;

    Vector2 initialPos;
    Ball_Movement ball_Movement;

    [HideInInspector] public bool puzzleSolved = false;

    private void Start()
    {
        ballTransform = GetComponent<RectTransform>();
        ball_Movement = GetComponent<Ball_Movement>();

        initialPos = ballTransform.position;
    }

    void Update()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(ballTransform, holeTransform.position))
        {
            ball_Movement.speed = 0;
            ball_Movement.x = 0;
            ball_Movement.y = 0;
            btnPlay.playing = false;
            puzzleSolved = true;
        }

        if(!puzzleSolved)
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(grassTransform, ballTransform.position))
            {
                ball_Movement.x = 0;
                ball_Movement.y = 0;
                resetBallPosition();
                btnPlay.playing = false;
            }
        }
    }

    public void resetBallPosition()
    {
        ball_Movement.speed = 200;
        puzzleSolved = false;
        ballTransform.position = initialPos;
        Debug.Log(ball_Movement.x);
        Debug.Log(ball_Movement.y);
    }
}
