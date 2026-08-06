using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int completeTasksIndex = 0;
    [HideInInspector] public int tasksLeft = 0;
    public GameObject HUD;
    public Image energyFiller;
    Agenda_Controller agenda;
    public Sprite[] avatarFeelings;
    public Image currentFeeling;
    public UI_Controller UI_Controller;
    public EnergyManager energyManager;

    Level_Manager level_Manager;

    void Start()
    {
        level_Manager = FindObjectOfType<Level_Manager>();

        level_Manager.calendar.sprite = level_Manager.calendarSprites[Level_Manager.levelIndex];

        int tasksAmount = level_Manager.levels[Level_Manager.levelIndex].tasks.Count;

        agenda = FindObjectOfType<Agenda_Controller>();

        agenda.generateTasks(tasksAmount, level_Manager.levels[Level_Manager.levelIndex].dropZonesAmount);

        
        agenda.writeTasks();

        if (Level_Manager.levelIndex >= 3)
        {
            if (Level_Manager.previousLevel_TasksAmount <= 2)
            {
                reduceEnergy(true);
            }
        }
            
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

        if (completeTasksIndex >= agenda.selectedTasks.Count)
        {
            if (Level_Manager.levelIndex + 1 >= level_Manager.levels.Count)
            {
                Level_Manager.levelIndex = 0;

                Time.timeScale = 0f;
                SceneManager.LoadScene("End Scene");
            }
            else
            {
                Level_Manager.previousLevel_TasksAmount = agenda.selectedTasks.Count;
                UI_Controller.showWinningScreen();
            }
        }
        
    }

    public void activateTasks()
    {
        foreach (GameObject task in agenda.selectedTasks)
        {
            if (task.activeInHierarchy)
            {
                Transform bubble = task.transform.Find("Bubble");
                bubble.gameObject.SetActive(true);
                task.layer = LayerMask.NameToLayer("Interactive Objects");
            }
            else
            {
                task.SetActive(true);
                Transform bubble = task.transform.Find("Bubble");
                bubble.gameObject.SetActive(true);
            }

            Distractions_UI originalDistraction = task.GetComponent<Distractions_UI>();
            if(originalDistraction != null)
            {
                originalDistraction.distractionToTask = true;
            }
        }

        foreach (GameObject distraction in level_Manager.levels[Level_Manager.levelIndex].leisureStuff)
        {
            distraction.SetActive(true);
            Transform bubble = distraction.transform.Find("DistractionBubble");
            bubble.gameObject.SetActive(true);
            //distraction.taskObject.layer = LayerMask.NameToLayer("Interactive Objects");
        }
    }

    public void reduceEnergy(bool taskCompleted)
    {
        float energyAmount = agenda.selectedTasks.Count;
        if(energyAmount < 2)
        {
            energyAmount = 2;
        }
        //Debug.Log(energyAmount + " energy amount");

        //float amount = 1f / (energyAmount * 2.5f);
        float amount = 0.2f;

        if (!taskCompleted)
            amount /= 2f;

        //Debug.Log(amount + " reduced");
        energyFiller.fillAmount -= amount;

        checkEnergy();
    }

    public void AddEnergy()
    {
        float energyAmount = agenda.selectedTasks.Count;
        if (energyAmount < 2)
        {
            energyAmount = 2;
        }

        float amount = 1f / (energyAmount * 2);

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
