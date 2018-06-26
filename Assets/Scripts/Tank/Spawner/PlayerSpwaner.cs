using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家生成器
/// </summary>
public class PlayerSpwaner : TankSpawner
{
    public int scoreOnDie;
    public bool isP1;

    private void Start()
    {
        if (!isP1 && !GameSystem.Setter.setting.isP2On)
        {
            Destroy(this);
            return;
        }
        GenerateTank();
    }
    protected override void OnTankDie(int value)
    {
        ScoreManager.SubScore(scoreOnDie, isP1);
        print(12);
        GenerateTank();
    }

    protected override void OnTankSpwan(Tank tank)
    {

    }
}
