using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int levelIndex = 0;
    int completeTasksIndex = 0;
    int tasksLeft = 0;
    public GameObject winScreen;
    public GameObject HUD;
    public Image energyFiller;
    public List<Levels_Controller> levels = new List<Levels_Controller>();
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
            winScreen.SetActive(true);
            HUD.SetActive(false);
            Time.timeScale = 0f;
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
        float reductionPerTask = 1f / levels[levelIndex].tasksAmount;
        if (taskCompleted)
        {
            //energyFiller.fillAmount = levels[levelIndex].tasksAmount / tasksLeft;}
            energyFiller.fillAmount = reductionPerTask;
        }
        else
        {
            energyFiller.fillAmount = reductionPerTask / 3; ;
        }
        
    }
}
