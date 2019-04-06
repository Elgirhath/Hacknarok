using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public enum TaskType
    {
        VAX,
        BABYSTEAL,
        DOCUMENTS
    } 
    public static GameManager instance;

    public TaskStruct[] tasks;
    
    
    
    
    private void Awake() {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class TaskStruct : System.Object
{
    public string name;
    public GameManager.TaskType type;
    public float instantiateTime;
}