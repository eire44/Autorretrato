using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int levelIndex = 0;
    int completeTasksIndex = 0;
    public GameObject winScreen;
    //public List<Levels_Controller> levels = new List<Levels_Controller>();
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
        if(completeTasksIndex >= 1) //levels[levelIndex].tasksAmount
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
