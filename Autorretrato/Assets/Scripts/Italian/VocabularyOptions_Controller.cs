using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VocabularyOptions_Controller : MonoBehaviour, IPointerClickHandler
{
    public bool correctAnswer = false;
    Image img;
    VocabularyPuzzle_Controller vocabularyPuzzle_Controller;

    private void Start()
    {
        img = GetComponent<Image>();
        vocabularyPuzzle_Controller = FindObjectOfType<VocabularyPuzzle_Controller>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        vocabularyPuzzle_Controller.changeCardColor(img, correctAnswer);
    }
}
