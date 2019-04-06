using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    private float timeLimit = 30.0f;
    private Image timeIndicator;
    private float timeLeft;
    public static Task CreateTask(GameObject taskPrefab, string taskName)
    {
        GameObject newTask = Instantiate(taskPrefab, TaskManager.instance.transform);
        newTask.GetComponentInChildren<Text>().text = taskName;
        return newTask.GetComponent<Task>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        timeIndicator = GetComponentInChildren<Image>();
        timeLeft = timeLimit;
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

    private void Perish(bool haveSucceeded)
    {
        if(haveSucceeded)
            
        Destroy(gameObject);
    }
}
