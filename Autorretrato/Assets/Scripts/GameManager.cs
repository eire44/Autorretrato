using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int levelIndex = 0;
    int completeTasksIndex = 0;
    public int tasksLeft = 0;
    public GameObject HUD;
    public Image energyFiller;
    public List<Levels_Controller> levels = new List<Levels_Controller>();
    public Sprite[] avatarFeelings;
    public Image currentFeeling;
    public UI_Controller UI_Controller;
    // Start is called before the first frame update
    void Start()
    {
        tasksLeft = levels[levelIndex].tasksAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void taskCompleted()
    {
        completeTasksIndex++;
        tasksLeft--;
        if(completeTasksIndex >= levels[levelIndex].tasksAmount) 
        {
            UI_Controller.showWinningScreen();
        }
    }

    public void activateTasks()
    {
        foreach (Task t in levels[levelIndex].tasks)
        {
            Transform bubble = t.taskObject.transform.Find("Bubble");
            bubble.gameObject.SetActive(true);
            t.taskObject.layer = LayerMask.NameToLayer("Interactive Objects");
        }
    }

    public void reduceEnergy(bool taskCompleted)
    {
        //float reductionPerTask = 1f / levels[levelIndex].tasksAmount;
        //if (taskCompleted)
        //{
        //    //energyFiller.fillAmount = levels[levelIndex].tasksAmount / tasksLeft;}
        //    energyFiller.fillAmount = reductionPerTask;
        //}
        //else
        //{
        //    energyFiller.fillAmount = reductionPerTask / 3; ;
        //}
        float amount = 1f / levels[levelIndex].tasksAmount;

        if (!taskCompleted)
            amount /= 6f;

        energyFiller.fillAmount -= amount;

        checkEnergy();
    }

    public void AddEnergy()
    {
        float amount = 1f / levels[levelIndex].tasksAmount;

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
