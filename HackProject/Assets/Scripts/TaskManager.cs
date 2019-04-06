using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public float overallTimeLimit;
    public GameObject taskPrefab;
    private List<Task> tasksList;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddTask()
    {
        //tasksList.Add(Instantiate());
        tasksList.Add(Instantiate(taskPrefab, transform));
    }
}
