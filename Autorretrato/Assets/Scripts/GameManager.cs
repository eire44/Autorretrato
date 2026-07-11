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
        tasksLeft = tasksAmount;

        agenda = FindObjectOfType<Agenda_Controller>();

        agenda.generateTasks(tasksAmount);

        while (agenda.selectedTasks.Count < tasksAmount)
        {
            agenda.selectedTasks.Add(level_Manager.levels[Level_Manager.levelIndex].tasks[Random.Range(0, tasksAmount)]);
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
        //float amount = 1f / agenda.selectedTasks.Count;

        //if (!taskCompleted)
        //    amount /= 6f;

        //energyFiller.fillAmount -= amount;

        //checkEnergy();
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

        energyManager.UpdateAesthetics(energyFiller.fillAmount);
    }
}
