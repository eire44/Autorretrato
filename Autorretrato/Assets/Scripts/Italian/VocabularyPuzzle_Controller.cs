using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VocabularyPuzzle_Controller : PuzzleManager
{
    public TMP_Text txtWord;
    public List<Vocabulary_Array> vocabularyList = new List<Vocabulary_Array>();
    public List<Image> imgOptions = new List<Image>();
    public List<Image> imgSquares = new List<Image>();

    int wordIndex = 0;
    bool playAudioOnce = false;

    public Color color_CorrectOption;
    public Color color_WrongOption;
    // Start is called before the first frame update
    void Start()
    {
        changeQuestion();
    }

    public void changeCardColor(Image cardPressed, bool correct)
    {
        int index = 0;
        foreach (Image card in imgOptions)
        {
            if(card == cardPressed)
            {
                if (correct)
                {
                    imgSquares[index].color = color_CorrectOption;
                    //coroutine esperar
                    correctAnswer();
                }
                else
                {
                    imgSquares[index].color = color_WrongOption;

                    playAudioOnce = false;
                    puzzleSolved = false;
                    activateFeedback(false, feedbackBubble);
                }
            }
            else
            {
                imgSquares[index].color = Color.white;
            }

            index++;
        }
    }

    public void correctAnswer()
    {
        if (wordIndex >= vocabularyList.Count)
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
        foreach (Image square in imgSquares)
        {
            square.color = Color.white;
        }

        txtWord.text = vocabularyList[wordIndex].word;

        for (int i = 0; i < imgOptions.Count; i++)
        {
            imgOptions[i].sprite = vocabularyList[wordIndex].vocabularyList[i].image;
            imgOptions[i].gameObject.GetComponent<VocabularyOptions_Controller>().correctAnswer = vocabularyList[wordIndex].vocabularyList[i].correctOption;
        }

        wordIndex++;
    }
}
