using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 行走器
/// </summary>
[DisallowMultipleComponent]
public class CompDriver : Comp
{
    public float speed;
    private Vector3 lastDir = Vector3.zero;
    private Rigidbody rig;

    /// <summary>
    /// 用于暂停
    /// </summary>
    [HideInInspector]
    public bool isWorking = true;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    //接口-----------------------------------
    public void Drive(Vector3 direction)
    {
        if (!isWorking) return;
        if (direction != lastDir && direction != Vector3.zero)
        {
            lastDir = direction;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        rig.velocity = direction * speed;
    }
}
