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
        enemyLastNum = maxEnemyNum;
        enemyNum = 0;
        uiEnemyNum = GetComponentInChildren<UIEnemyNum>();
        uiEnemyNum.ShowEnemyNum(enemyLastNum);

        P1Health = P1MaxHealth;
        if (GameSystem.Setter.setting.isP2On)
        {
            P2Health = P2MaxHealth;
        }
        else
        {
            P2Health = 0;
        }
        uIPlayerHealth = GetComponentInChildren<UIPlayerHealth>();
        uIPlayerHealth.ShowHealth(P1Health, P2Health);
    }

    public static void Init()
    {
        p1Score = 0;
        p2Score = 0;
    }

    //UI显示相关
    private static UIEnemyNum uiEnemyNum;

    public static void SubEnemyLastNum()
    {
        enemyLastNum--;
        uiEnemyNum.ShowEnemyNum(enemyLastNum);
    }

    //玩家生命相关
    public static int P1Health;
    public static int P2Health;

    public int P1MaxHealth;
    public int P2MaxHealth;

    private static UIPlayerHealth uIPlayerHealth;
    public static void SubHealth(bool isP1)
    {
        if (isP1)
        {
            P1Health--;
        }
        else
        {
            P2Health--;
        }

        if (P1Health + P2Health <= 0)
        {
            GameSystem.InnerSystem.GameMessageManager.SendGameMessage(GameSystem.InnerSystem.GameMessage.Lose);
        }

        uIPlayerHealth.ShowHealth(P1Health, P2Health);
    }

    public static void AddHealth()
    {
        P1Health++;
        if (GameSystem.Setter.setting.isP2On)
        {
            P2Health++;
        }
        uIPlayerHealth.ShowHealth(P1Health, P2Health);
    }
}
