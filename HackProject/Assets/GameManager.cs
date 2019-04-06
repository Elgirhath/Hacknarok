using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    public enum TaskType
    {
        VAX,
        BABYSTEAL,
        DOCUMENTS
    } 
    public static GameManager instance;

    public List<TaskStruct> tasks;
    private TaskManager taskManager;
    
    
    private void Awake() {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        taskManager = TaskManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = tasks.Count-1; i >= 0; --i)
        {
            if (Time.time >= tasks[i].instantiateTime)
            {
                taskManager.AddTask(tasks[i]);
                tasks.RemoveAt(i);
            }
        }
    }

    public void EndGame(bool haveFailed)
    {
        SceneManager.LoadScene(haveFailed ? "GameOver" : "Success");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}

[System.Serializable]
public class TaskStruct : System.Object
{
    public string name;
    public GameManager.TaskType type;
    public float instantiateTime;
}