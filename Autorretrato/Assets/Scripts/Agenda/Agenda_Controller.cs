using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Agenda_Controller : MonoBehaviour
{
    public List<Task> tasksList = new List<Task>();
    
    public HashSet<Task> selectedTasks = new HashSet<Task>();

    [HideInInspector] public TMP_Text[] tasksTxts;
    public GameObject[] taskTickets;
    public DropZone[] dropZones;
    int taskIndex = 0;

    public void generateTasks(int tasksAmount)
    {
        tasksTxts = new TMP_Text[tasksAmount];

        for (int i = 0; i < tasksAmount; i++)
        {
            taskTickets[i].SetActive(true);
            dropZones[i].gameObject.SetActive(true);
            tasksTxts[i] = taskTickets[i].transform.Find("txt").GetComponent<TMP_Text>();
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
