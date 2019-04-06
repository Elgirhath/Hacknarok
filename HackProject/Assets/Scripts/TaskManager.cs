using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public float overallTimeLimit;
    public GameObject taskPrefab;

    public static TaskManager instance;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake() {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Task.CreateTask(taskPrefab);
    }
}
