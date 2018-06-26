using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 坦克
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(CompDriver))]
[RequireComponent(typeof(CompShooter))]
[RequireComponent(typeof(ActiveStateMachine))]
public class Tank : AmmoDetector
{
    [Header("阵营")]
    public GameSystem.CampFlag campFlag;

    //组件----------------------------------------
    private CompDriver driver;
    private CompShooter shooter;
    private ActiveStateMachine stateMachine;

    private void Start()
    {
        driver = GetComponent<CompDriver>();
        shooter = GetComponent<CompShooter>();
        stateMachine = GetComponent<ActiveStateMachine>();
        health = stateMachine.states.Length;

#if UNITY_EDITOR
        //编辑器模式自检
        if (driver == null || shooter == null || stateMachine == null)
        {
            Debug.LogError("坦克组件不全！");
        }
        if (health == 0)
        {
            Debug.LogError("请添加坦克状态！");
        }
#endif
    }

    //血量控制------------------------------------
    private int health;
    protected override void Hit(Ammo ammo)
    {
        if (ammo.campFlag != campFlag)
        {
            ammo.Boom();
            health--;
            if (health <= 0) Die();
        }
    }

    [Header("死亡时给生成器传递的参数")]
    public float score;
    public event System.Action<float> onDie;
    private void Die()
    {
        if (onDie != null) onDie(score);
        Destroy(gameObject);
    }

    //接口----------------------------------------
    public void Drive(Vector3 direction)
    {
        dir = direction;
    }

    private Vector3 dir;
    private void Update()
    {
        driver.Drive(dir);
        dir = Vector3.zero;
    }
    public void Shoot()
    {
        shooter.Shoot();
    }
}
