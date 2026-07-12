using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public static int levelIndex = 0;
    public List<Level> levels = new List<Level>();
    [HideInInspector] public static int previousLevel_TasksAmount = 0;
}
