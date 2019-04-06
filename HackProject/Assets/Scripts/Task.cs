using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{

    private float timeLimit = 30.0f;
    private Image timeIndicator;
    private float timeLeft;
    private Score score;
    public GameManager.TaskType type;
    public static Task CreateTask(GameObject taskPrefab, string taskName, GameManager.TaskType type)
    {
        GameObject newTask = Instantiate(taskPrefab, TaskManager.instance.transform);
        newTask.GetComponentInChildren<Text>().text = taskName;
        Task task = newTask.GetComponent<Task>();
        task.type = type;
        return task;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        timeIndicator = GetComponentInChildren<Image>();
        timeLeft = timeLimit;
        score = Score.instance;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeIndicator.fillAmount = timeLeft/timeLimit;
        if (timeLeft <= 0)
        {
            Perish(false);
        }
    }

    public void Perish(bool haveSucceeded)
    {
        if(haveSucceeded)
            score.ChangeScore(1);
        else
            score.ChangeScore(-1);
        
        Destroy(gameObject);
    }
}
