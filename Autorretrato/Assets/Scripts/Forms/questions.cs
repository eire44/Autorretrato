using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class questions
{
    public string questionText;
    public List<answers> answers = new List<answers>();
}
