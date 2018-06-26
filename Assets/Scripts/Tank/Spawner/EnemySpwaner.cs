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
            GenerateTank();
            spwanTimer = Random.Range(spwanMinTime, spwanMaxTime);
        }
    }

    protected override void OnTankDie(float value)
    {
        ScoreManager.AddScore(value);
    }

    protected override void OnTankSpwan(Tank tank)
    {
        //记录敌机数量
    }
}
