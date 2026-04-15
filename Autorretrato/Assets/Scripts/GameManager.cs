using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int levelIndex = 0;
    int completeTasksIndex = 0;
    public GameObject winScreen;
    public List<Levels_Controller> levels = new List<Levels_Controller>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void taskCompleted()
    {
        completeTasksIndex++;
        if(completeTasksIndex >= levels[levelIndex].tasksAmount) 
        {
            winScreen.SetActive(true);
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
}
