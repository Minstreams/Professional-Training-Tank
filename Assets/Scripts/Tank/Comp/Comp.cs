using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 坦克组件
/// </summary>
public class Comp : MonoBehaviour {
    protected Tank tank;

    protected virtual void Awake()
    {
        tank = GetComponent<Tank>();
        if (tank == null) Debug.LogError("这个组件没有坦克管理！");
    }
}
