using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogs_Controller : MonoBehaviour
{

    [TextArea(1, 3)] public string[] dialogs;
    public TMP_Text dialogText;
    int dialogIndex = 0;

    bool playingIntro = true;
    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = dialogs[dialogIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextDialog()
    {
        if(playingIntro)
        {
            dialogIndex++;
            dialogText.text = dialogs[dialogIndex];
        }
        else
        {
            dialogText.text = "...";
        }
        
    }
}
