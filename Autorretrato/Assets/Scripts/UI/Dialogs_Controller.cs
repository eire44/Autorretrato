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
    public Level_Manager level_Manager;
    
    void Start()
    {
        if(Level_Manager.levelIndex == 0)
        {
            btnControlsOK.SetActive(true);
        }
        else
        {
            btnControlsOK.SetActive(false);
        }

        changeDialogTxt(level_Manager.levels[Level_Manager.levelIndex].levelMessage);
        
        if(Level_Manager.levelIndex >= 3)
        {
            if (Level_Manager.previousLevel_TasksAmount <= 2)
            {
                changeDialogTxt("I feel like I haven't been productive lately :(. Maybe I should do more");
            }
        }
        
    }

    public void changeDialogTxt(string newTxt)
    {
        if(btnControlsOK != null)
        {
            if (btnControlsOK.activeInHierarchy)
            {
                controlsUnderstood();
            }
            dialogText.text = newTxt;
        }
    }

    public void controlsUnderstood ()
    {
        btnControlsOK.SetActive(false);
        dialogText.text = dialogs[dialogIndex];
    }
}
