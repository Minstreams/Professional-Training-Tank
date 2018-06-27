using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    private void Start()
    {
        if (GameSystem.Setter.setting.isP2On)
        {
            GetComponent<TextMesh>().text = "SCORE\nP1: " + ScoreManager.p1Score + "\nP2: " + ScoreManager.p2Score;
        }
        else
        {
            GetComponent<TextMesh>().text = "SCORE\n" + ScoreManager.p1Score;
        }
    }
}
