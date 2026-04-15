using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Task
{
    [TextArea] public string taskName = "";
    public GameObject taskObject;
}
