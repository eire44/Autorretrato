using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogs_Controller : MonoBehaviour
{
    [TextArea(1, 3)] public string[] dialogs;
    public TMP_Text dialogText;
    int dialogIndex = 0;
    public GameObject btnControlsOK;
    // Start is called before the first frame update
    void Start()
    {
        if(true) //persistir primer partida
        {
            btnControlsOK.SetActive(true);
        }
        else
        {
            btnControlsOK.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeDialogTxt(string newTxt)
    {
        if(btnControlsOK.activeInHierarchy)
        {
            controlsUnderstood();
        }
        dialogText.text = newTxt;
    }

    //public void nextDialog()
    //{
    //    dialogText.text = dialogs[dialogIndex];
    //    dialogIndex++;
    //}

    public void controlsUnderstood ()
    {
        btnControlsOK.SetActive(false);
        dialogText.text = dialogs[dialogIndex];
    }
}
