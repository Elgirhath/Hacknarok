using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    private float timeLimit = 30.0f;
    private Image timeIndicator;
    private float timeLeft;
    public static void CreateTask(GameObject taskPrefab)
    {
        GameObject newTask = Instantiate(taskPrefab, TaskManager.instance.transform);
        newTask.GetComponentInChildren<Text>().text = "Hehehue";
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
    }
    
    
}
