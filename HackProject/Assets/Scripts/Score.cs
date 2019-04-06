using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public static Score instance;
    private Text scoreDisplay;
    private void Awake() {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void ChangeScore(int value)
    {
        score += value;
        scoreDisplay.text = "Score: " + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
