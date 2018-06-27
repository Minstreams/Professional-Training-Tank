using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

/// <summary>
/// 编辑器模式下自动对齐
/// </summary>
[ExecuteInEditMode]
[AddComponentMenu("Function/Auto Align")]
public class AutoAlignBySection : MonoBehaviour
{
    [Header("【自动对齐组件】"), Header("对齐单元数"), Range(1, 8)]
    public int section = 4;

    private const float unit = 0.16f;

    private void Update()
    {
        transform.position = new Vector3(((int)((transform.position.x + section * unit / 2) / (section * unit))) * (section * unit), ((int)((transform.position.y + section * unit / 2) / (section * unit))) * (section * unit), 1);
    }
}
#endif