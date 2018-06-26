using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可破坏墙
/// </summary>
public class FragileWall : AmmoDetector
{
    protected override void Hit(Ammo ammo)
    {
        ammo.DieWithWall();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(1);
        if (other.tag == "Ammo")
        {
            Destroy(gameObject);
        }
    }
}
