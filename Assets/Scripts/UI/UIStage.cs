using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStage : MonoBehaviour
{

    private void Start()
    {
        GetComponent<TextMesh>().text = "STAGE " + (GameSystem.Setter.setting.currentScene + 1);
    }
}
