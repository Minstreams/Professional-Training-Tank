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
    public bool isPlayer = false;

    //组件----------------------------------------
    [HideInInspector]
    public CompDriver driver;
    public CompShooter shooter;
    private ActiveStateMachine stateMachine;

    private void Start()
    {
        driver = GetComponent<CompDriver>();
        shooter = GetComponent<CompShooter>();
        stateMachine = GetComponent<ActiveStateMachine>();
        health = stateMachine.states.Length;
        //最后一个状态用于加Buff
        if (isPlayer) health--;

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
        if (isInvisible)
        {
            return;
        }
        if (ammo.campFlag != campFlag)
        {
            health--;

            if (health <= 0)
            {
                ammo.Boom();
                Die();
            }
            else
            {
                ammo.BoomSlightly();
                stateMachine.ChangeState(health - 1);
            }
        }
    }

    [Header("死亡时给生成器传递的参数")]
    public int score;
    public event System.Action<int> onDie;

    private bool died = false;
    public void Die()
    {
        if (died) return;
        died = true;
        if (onDie != null) onDie(score);
        Destroy(gameObject);
    }


    public void Boom()
    {
        GameSystem.AudioSystem.Play(GameSystem.Setter.setting.audioBlast);
        GameObject.Instantiate(GameSystem.Setter.setting.boomPrefab, transform.position, Quaternion.identity, null);
        Die();
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

    //Buff----------------------------------------
    /// <summary>
    /// 无敌
    /// </summary>
    private bool isInvisible;

    public void BuffSetInvisible(bool b)
    {
        if (b)
        {
            isInvisible = true;
            stateMachine.ChangeState(stateMachine.states.Length - 1);
        }
        else
        {
            isInvisible = false;
            stateMachine.ChangeState(health - 1);
        }
    }
}
