using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌机ai核心
/// </summary>
public class EnemyCore : Comp
{
    public float minTurnTime;
    public float maxTurnTime;
    public float shootTime;

    private float turnTimer;
    private float shootTimer;

    private Vector3 dir;

    private void Start()
    {
        turnTimer = Random.Range(minTurnTime, maxTurnTime);
        shootTimer = shootTime;
        dir = RandomDir();
    }

    private void Update()
    {
        turnTimer -= Time.deltaTime;
        if (turnTimer <= 0)
        {
            turnTimer = Random.Range(minTurnTime, maxTurnTime);
            dir = RandomDir();
        }
        tank.Drive(dir);

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            shootTimer = shootTime;
            tank.Shoot();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag != "Tank")
        //{
        dir = RandomDir();
        //}
    }

    private Vector3 RandomDir()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                return Vector3.up;
            case 1:
                return Vector3.down;
            case 2:
                return Vector3.left;
            default:
                return Vector3.right;
        }
    }
}
