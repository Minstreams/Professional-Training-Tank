using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏分数管理器
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static int p1Score;
    public static int p2Score;

    public int maxEnemyNum;

    public static int enemyLastNum { get; private set; }
    public static int enemyNum;
    public static void AddScore(int value)
    {
        p1Score += value;
        p2Score += value;
    }
    public static void SubScore(int value, bool isP1)
    {
        if (isP1)
        {
            p1Score -= value;
        }
        else
        {
            p2Score -= value;
        }
    }
    private void Start()
    {
        p1Score = 0;
        p2Score = 0;
        enemyLastNum = maxEnemyNum;
        enemyNum = 0;
        uiEnemyNum = GetComponentInChildren<UIEnemyNum>();
        uiEnemyNum.ShowEnemyNum(enemyLastNum);
    }

    //UI显示相关
    private static UIEnemyNum uiEnemyNum;

    public static void SubEnemyLastNum()
    {
        enemyLastNum--;
        uiEnemyNum.ShowEnemyNum(enemyLastNum);
    }
}
