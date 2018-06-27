using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 无敌道具
/// </summary>
public class ItemInvisible : Item
{
    protected override void BuffOff(Tank tank)
    {
        tank.BuffSetInvisible(false);
    }

    protected override void BuffOn(Tank tank)
    {
        tank.BuffSetInvisible(true);
    }
}
