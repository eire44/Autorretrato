using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Agenda_Controller : MonoBehaviour
{
    //public List<Task> tasksList = new List<Task>();
    
    public HashSet<GameObject> selectedTasks = new HashSet<GameObject>();

    [HideInInspector] public TMP_Text[] tasksTxts;
    public GameObject[] taskTickets;
    public DropZone[] dropZones;
    int taskIndex = 0;
    Level_Manager level_Manager;
    private void Awake()
    {
        var controllers = FindObjectsOfType<Agenda_Controller>();
        //Debug.Log($"Hay {controllers.Length} Agenda_Controller en la escena.");
    }

    private void Start()
    {
        level_Manager = FindObjectOfType<Level_Manager>();

        //for (int i = 0; i < taskTickets.Length; i++)
        //{
        //    Debug.Log($"[{i}] = {taskTickets[i]}");
        //}
    }

    public void generateTasks(int tasksAmount, int dropZonesAmount)
    {
        //Debug.Log($"Start: {taskTickets.Length}");
        tasksTxts = new TMP_Text[tasksAmount];

        for (int i = 0; i < tasksAmount; i++)
        {
            taskTickets[i].SetActive(true);
            //dropZones[i].gameObject.SetActive(true);
            tasksTxts[i] = taskTickets[i].transform.Find("txt").GetComponent<TMP_Text>();
        }

        for (int i = 0; i < dropZonesAmount; i++)
        {
            dropZones[i].gameObject.SetActive(true);
        }
    }
    
    public void writeTasks()
    {
        foreach (Task t in level_Manager.levels[Level_Manager.levelIndex].tasks)
        {
            if(tasksTxts[taskIndex] != null)
            {
                tasksTxts[taskIndex].text = t.taskName;
                chosenTask chosenTask = taskTickets[taskIndex].GetComponent<chosenTask>();
                if(chosenTask != null)
                {
                    chosenTask.taskObject = t.taskObject;
                }

                taskIndex++;
            } else
            {
                Debug.Log("Oh no! There are too many tasks for this agenda");
            }
        }
    }
}
