using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : TankSpawner
{
    [Header("随机生成时间")]
    public float spwanMinTime;
    public float spwanMaxTime;

    private float spwanTimer;


    private void Update()
    {
        spwanTimer -= Time.deltaTime;
        if (spwanTimer <= 0)
        {
            if (ScoreManager.enemyLastNum <= 0)
            {
                return;
            }
            GenerateTank();
            spwanTimer = Random.Range(spwanMinTime, spwanMaxTime);
        }
    }

    protected override void OnTankDie(int value)
    {
        ScoreManager.AddScore(value);
        ScoreManager.enemyNum--;
        if (ScoreManager.enemyNum <= 0 && ScoreManager.enemyLastNum <= 0)
        {
            GameSystem.InnerSystem.GameMessageManager.SendGameMessage(GameSystem.InnerSystem.GameMessage.Win);
        }
    }

    protected override void OnTankSpwan(Tank tank)
    {
        ScoreManager.SubEnemyLastNum();
        ScoreManager.enemyNum++;
    }
}
