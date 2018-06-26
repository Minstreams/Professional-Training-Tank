using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 无法被破坏的墙
/// </summary>
public class SolidWall : AmmoDetector
{
    protected override void Hit(Ammo ammo)
    {
        ammo.Boom();
    }
}
