using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Forms_Controller : PuzzleManager
{
    public List<questions> questions = new List<questions>();

    int questionIndex = 0;

    public TMP_Text txtQuestion;
    public TMP_Text txtAnswer1;
    public TMP_Text txtAnswer2;

    public List<options_Controller> options = new List<options_Controller>();
    bool playAudioOnce = false;
    public GameObject greenCheck1;
    public GameObject greenCheck2;

    public AudioSource correctAnswer_Audio;
    public AudioSource incorrectAnswer_Audio;
    // Start is called before the first frame update
    void Start()
    {
        changeQuestion();
    }

    public void submitAnswer()
    {
        if (checkAnswer())
        {
            correctAnswer_Audio.Play();
            correctAnswer();
        }
        else
        {
            incorrectAnswer_Audio.Play();
            playAudioOnce = false;
            puzzleSolved = false;
            activateFeedback(false, feedbackBubble);
        }
    }

    bool checkAnswer()
    {
        foreach (options_Controller o in options)
        {
            if (o.correctAnswer)
            {
                if (!o.checkAnswer)
                {
                    return false;
                }
            }
            else
            {
                if (o.checkAnswer)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void correctAnswer()
    {
        if (questionIndex >= questions.Count)
        {
            if (!playAudioOnce)
            {
                playAudioOnce = true;
                puzzleSolved = true;
                activateFeedback(true, feedbackBubble);
            }
        }
        else
        {
            changeQuestion();
        }
    }

    void changeQuestion()
    {
        txtQuestion.text = questions[questionIndex].questionText;
        txtAnswer1.text = questions[questionIndex].answers[0].answer;
        txtAnswer2.text = questions[questionIndex].answers[1].answer;

        options[0].correctAnswer = questions[questionIndex].answers[0].correctAnswer;
        options[1].correctAnswer = questions[questionIndex].answers[1].correctAnswer;

        questionIndex++;

        greenCheck1.SetActive(false);
        greenCheck2.SetActive(false);

        foreach (options_Controller o in options)
        {
            o.checkAnswer = false;
        }
    }
}
