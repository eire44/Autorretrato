using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Agenda_Controller : MonoBehaviour
{
    public List<Task> tasksList = new List<Task>();
    
    public HashSet<Task> selectedTasks = new HashSet<Task>();

    TMP_Text[] tasksTxts;
    public GameObject[] taskTickets;
    public GameObject[] tasksDropZones;
    int taskIndex = 0;

    public void generateTasks(int tasksAmount)
    {
        tasksTxts = new TMP_Text[tasksAmount];

        for (int i = 0; i < tasksAmount; i++)
        {
            taskTickets[i].SetActive(true);
            tasksDropZones[i].SetActive(true);
            tasksTxts[i] = taskTickets[i].transform.Find("txt").GetComponent<TMP_Text>();
            Debug.Log(tasksTxts[i].name);
        }
    }
    
    public void writeTasks()
    {
        foreach (Task t in selectedTasks)
        {
            if(tasksTxts[taskIndex] != null)
            {
                tasksTxts[taskIndex].text = t.taskName;
                taskIndex++;
            } else
            {
                Debug.Log("Oh no! There are too many tasks for this agenda");
            }
        }
    }
}
