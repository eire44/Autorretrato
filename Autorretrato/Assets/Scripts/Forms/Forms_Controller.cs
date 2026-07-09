using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Forms_Controller : PuzzleManager
{
    public List<string> questions = new List<string>();
    public List<answers[]> answers = new List<answers[]>();

    int questionIndex = 0;

    public TMP_Text txtQuestion;
    public TMP_Text txtAnswer1;
    public TMP_Text txtAnswer2;

    public List<options_Controller> options = new List<options_Controller>();
    bool playAudioOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        changeQuestion();
    }

    public void submitAnswer()
    {
        if (checkAnswer())
        {
            correctAnswer();
        }
        else
        {
            playAudioOnce = false;
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
        txtQuestion.text = questions[questionIndex];
        txtAnswer1.text = answers[questionIndex][0].answer;
        txtAnswer2.text = answers[questionIndex][1].answer;

        options[0].correctAnswer = answers[questionIndex][0].correctAnswer;
        options[1].correctAnswer = answers[questionIndex][1].correctAnswer;

        questionIndex++;
    }
}
