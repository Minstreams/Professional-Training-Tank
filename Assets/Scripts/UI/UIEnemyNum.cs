using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnemyNum : MonoBehaviour
{
    public GameObject[] icons;

    public void ShowEnemyNum(int num)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < num)
            {
                icons[i].SetActive(true);
            }
            else
            {
                icons[i].SetActive(false);
            }
        }
    }
}
