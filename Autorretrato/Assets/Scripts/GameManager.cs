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

    int tasksNumber = 3;
    
    void Start()
    {
        tasksLeft = tasksNumber;

        agenda = FindObjectOfType<Agenda_Controller>();

        agenda.generateTasks(tasksNumber);

        while (agenda.selectedTasks.Count < tasksNumber)
        {
            agenda.selectedTasks.Add(agenda.tasksList[Random.Range(0, agenda.tasksList.Count)]);
        }

        agenda.writeTasks();
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
        foreach (Task t in agenda.selectedTasks)
        {
            /* cuando hayan mas tareas, en vez de habilitarlos con la layer y aparecer 
             las bubbles, activar o desactivar todo el t.taskObject */
            Transform bubble = t.taskObject.transform.Find("Bubble");
            bubble.gameObject.SetActive(true);
            t.taskObject.layer = LayerMask.NameToLayer("Interactive Objects");
        }
    }

    public void reduceEnergy(bool taskCompleted)
    {
        float amount = 1f / agenda.selectedTasks.Count;

        if (!taskCompleted)
            amount /= 6f;

        energyFiller.fillAmount -= amount;

        checkEnergy();
    }

    public void AddEnergy()
    {
        float amount = 1f / agenda.selectedTasks.Count;

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
    }
}
