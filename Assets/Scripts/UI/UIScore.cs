using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScore : MonoBehaviour {
    private void Start()
    {
        GetComponent<TextMesh>().text = "SCORE\nP1: " + ScoreManager.p1Score + "\nP2: " + ScoreManager.p2Score;
    }
}
