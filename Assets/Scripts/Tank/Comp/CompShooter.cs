using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 射击组件
/// </summary>
[DisallowMultipleComponent]
public class CompShooter : Comp
{
    public float ammoSpeed { get { return GameSystem.Setter.setting.ammoSpeed; } }
    public Transform GunPivot;
    private int id;
    private void Start()
    {
        id = AmmoManager.GetId();
    }

    //接口-----------------------------------
    public void Shoot()
    {
        if (!isWorking) return;
        AmmoManager.GenerateAmmo(GunPivot.position, transform.up, ammoSpeed, id, tank.campFlag);
    }

    /// <summary>
    /// 用于暂停
    /// </summary>
    [HideInInspector]
    private bool isWorking = true;

    public void Stop()
    {
        isWorking = false;
    }

    public void Conti()
    {
        isWorking = true;
    }

}
