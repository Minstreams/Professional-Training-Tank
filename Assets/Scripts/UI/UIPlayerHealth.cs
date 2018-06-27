using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerHealth : MonoBehaviour
{
    public TextMesh p1Text;
    public TextMesh p2Text;

    public GameObject p2GameObject;

    private void Start()
    {
        p2GameObject.SetActive(GameSystem.Setter.setting.isP2On);
    }

    public void ShowHealth(int p1Health, int p2Health)
    {
        p1Text.text = p1Health.ToString();
        p2Text.text = p2Health.ToString();
    }
}
