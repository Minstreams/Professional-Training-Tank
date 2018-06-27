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
		float x = transform.position.x - Eagle.position.x;
		float y = transform.position.y - Eagle.position.y;
		int i = Random.Range(0, 100);
		if (i < 10)
		{
			if (x > 0)
			{
				return Vector3.right;
			}
			else
			{
				return Vector3.left;
			}
		}
		if (i >= 10 && i < 20)
		{
			if (y > 0)
			{
				return Vector3.up;
			}
			else
			{
				return Vector3.down;
			}
		}
		if (i >= 20 && i < 60)
		{
			if (x > 0)
			{
				return Vector3.left;
			}
			else
			{
				return Vector3.right;
			}
		}
		if (i >= 60 && i < 100)
		{
			if (y > 0)
			{
				return Vector3.down;
			}
			else
			{
				return Vector3.up;
			}
		}
		return Vector3.up;
    }
}
