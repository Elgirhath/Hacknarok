using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Docs : MonoBehaviour, Interactable
{
    private bool done;
    private TaskManager taskManager;
    public float moveTolerance;
    private Transform initialPosition;
    public void Interact(InteractController controller) {
        
        Task task = taskManager.TaskExists(GameManager.TaskType.DOCUMENTS);
        if (task)
        {
            initialPosition = controller.gameObject.transform;
            
            
            Debug.Log("Nice!");
            task.Perish(true);
        }
        
        else
        {
            if (done)
            {
                Debug.Log("Dude, are you high?! You have already done that task!");
            }
            Debug.Log("Not now man! Now is not the time for that!");
        }
    }
    void Start()
    {
        taskManager = TaskManager.instance;
        done = false;
    }
}
