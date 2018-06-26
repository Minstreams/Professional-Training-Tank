using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : AmmoDetector
{
    public GameSystem.CampFlag campFlag;
    protected override void Hit(Ammo ammo)
    {
        if (ammo.campFlag != campFlag)
        {
            if (ammo != null) ammo.Boom();
            Boom();
        }
    }

    /// <summary>
    /// 爆炸
    /// </summary>
    [ContextMenu("Boom!")]
    public void Boom()
    {
        GameObject.Instantiate(GameSystem.Setter.setting.boomPrefab, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public void DieSilent()
    {
        Destroy(gameObject);
    }

    public void DieWithWall()
    {
        GameObject.Instantiate(GameSystem.Setter.setting.ammoWallArea, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }
}
