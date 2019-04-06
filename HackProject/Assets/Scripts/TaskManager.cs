using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{    
    public float overallTimeLimit;
    private float timeLeft;
    public GameObject taskPrefab;

    public static TaskManager instance;

    private int minutesLeft;
    private int secondsLeft;

    private Text timeLeftText;

    private GameManager gameManager;

    private List<Task> taskList = new List<Task>();
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = overallTimeLimit;
        timeLeftText = GetComponentInChildren<Text>();
        gameManager = GameManager.instance;
    }

    private void Awake() {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
    }

    public void AddTask(TaskStruct tStruct)
    {
        taskList.Add(Task.CreateTask(taskPrefab, tStruct.name, tStruct.type));
    }

    public Task TaskExists(GameManager.TaskType tType)
    {
        foreach (var t in taskList)
        {
            if (tType == t.type)
            {
                return t;
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        secondsLeft = (int) timeLeft % 60;
        minutesLeft = (int) timeLeft / 60;
        if(secondsLeft < 10)
            timeLeftText.text = "0" + minutesLeft + ":0" + secondsLeft;
        else
            timeLeftText.text = "0" + minutesLeft + ":" + secondsLeft;

        if (timeLeft <= 0)
        {
            gameManager.EndGame(true);
        }
    }
}
