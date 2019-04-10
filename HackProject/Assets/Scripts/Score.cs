using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private int _score;

    public int score {
        get { return _score; }
        set {
            _score = value;
            if (scoreDisplay)
                scoreDisplay.text = "Score: " + score;
        }
    }
    public static Score instance;
    private Text scoreDisplay;
    private void Awake() {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        scoreDisplay = GetComponent<Text>();
    }
}
