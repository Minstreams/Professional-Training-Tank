using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家生成器
/// </summary>
public class PlayerSpwaner : TankSpawner
{
    private void Start()
    {
        GenerateTank();
    }
    protected override void OnTankDie(float value)
    {
        GenerateTank();
    }

    protected override void OnTankSpwan(Tank tank)
    {

    }
}
