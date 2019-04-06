using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    private float timeLimit;
    private Image timeIndicator;

    private float initTime;

    private void SetNew(string name, float timeLimit)
    {
        this.timeLimit = timeLimit;
        initTime = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeIndicator = GetComponentInChildren<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float timePassed = Time.time - initTime;
        timeIndicator.fillAmount = timePassed / initTime;
    }
    
    
}
