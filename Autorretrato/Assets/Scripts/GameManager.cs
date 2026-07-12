using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int levelIndex = 0;
    int completeTasksIndex = 0;
    [HideInInspector] public int tasksLeft = 0;
    public GameObject HUD;
    public Image energyFiller;
    Agenda_Controller agenda;
    public Sprite[] avatarFeelings;
    public Image currentFeeling;
    public UI_Controller UI_Controller;
    public EnergyManager energyManager;

    int tasksNumber = 3;
    Level_Manager level_Manager;

    void Start()
    {
        level_Manager = FindObjectOfType<Level_Manager>();

        //tasksLeft = tasksNumber;
        int tasksAmount = level_Manager.levels[Level_Manager.levelIndex].tasks.Count;

        agenda = FindObjectOfType<Agenda_Controller>();

        agenda.generateTasks(tasksAmount, level_Manager.levels[Level_Manager.levelIndex].dropZonesAmount);

        
        agenda.writeTasks();
    }

    public void saveSelectedTasks()
    {
        foreach (GameObject taskTicket in agenda.taskTickets)
        {
            DraggableObject dO = taskTicket.GetComponent<DraggableObject>();
            if(dO != null)
            {
                if (dO.draggablePlaced)
                {
                    tasksLeft++;

                    chosenTask chosenTask = dO.gameObject.GetComponent<chosenTask>();
                    agenda.selectedTasks.Add(chosenTask.taskObject);
                }
            }
        }
    }

    public void taskCompleted()
    {
        completeTasksIndex++;
        tasksLeft--;
        if(completeTasksIndex >= agenda.selectedTasks.Count) 
        {
            UI_Controller.showWinningScreen();
        }
    }

    public void activateTasks()
    {
        foreach (GameObject task in agenda.selectedTasks)
        {
            /* cuando hayan mas tareas, en vez de habilitarlos con la layer y aparecer 
             las bubbles, activar o desactivar todo el t.taskObject */
            ////Transform bubble = t.taskObject.transform.Find("Bubble");
            ////bubble.gameObject.SetActive(true);
            ////t.taskObject.layer = LayerMask.NameToLayer("Interactive Objects");
            
            task.SetActive(true);
        }

        foreach (GameObject distraction in level_Manager.levels[Level_Manager.levelIndex].leisureStuff)
        {
            distraction.SetActive(true);
            //Transform bubble = distraction.taskObject.transform.Find("Bubble");
            //bubble.gameObject.SetActive(true);
            //distraction.taskObject.layer = LayerMask.NameToLayer("Interactive Objects");
        }
    }

    public void reduceEnergy(bool taskCompleted)
    {
        float amount = 1f / (agenda.selectedTasks.Count * 2);

        if (!taskCompleted)
            amount /= 6f;

        energyFiller.fillAmount -= amount;

        checkEnergy();
    }

    public void AddEnergy()
    {
        float amount = 1f / (agenda.selectedTasks.Count * 2);

        energyFiller.fillAmount += amount;

        checkEnergy();
    }

    void checkEnergy()
    {
        if (energyFiller.fillAmount <= 0f)
        {
            UI_Controller.showEndGameScreen("You´re out of energy :(");
        }
        else if (energyFiller.fillAmount <= 0.4f)
        {
            currentFeeling.sprite = avatarFeelings[2];
        }
        else if (energyFiller.fillAmount <= 0.7f)
        {
            currentFeeling.sprite = avatarFeelings[1];
        }
        else
        {
            currentFeeling.sprite = avatarFeelings[0];
        }

        energyManager.UpdateAesthetics(energyFiller.fillAmount);
    }
}
