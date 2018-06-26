using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自我毁灭组件
/// </summary>
[AddComponentMenu("Function/Self Destroyer")]
public class SelfDestroyer : MonoBehaviour {
    public float second;

    private void Update()
    {
        second -= Time.deltaTime;
        if (second <= 0) Destroy(gameObject);
    }
}
