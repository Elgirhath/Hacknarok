using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScoreHelper : MonoBehaviour
{
    void Start()
    {
        Score.instance.score = 0;
    }
}
