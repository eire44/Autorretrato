using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractions_UI : MonoBehaviour
{
    public GameObject distractionScreen;
    public string txtDialog;
    DistractionsManager distractionsManager;

    private void Start()
    {
        distractionsManager = FindObjectOfType<DistractionsManager>();
    }

    public void openTaskUI()
    {
        distractionsManager.openTaskUI(distractionScreen);
    }
}
