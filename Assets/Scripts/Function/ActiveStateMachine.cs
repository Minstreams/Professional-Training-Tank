using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通用状态机
/// </summary>
[AddComponentMenu("Function/Active State Machine")]
public class ActiveStateMachine : MonoBehaviour {
    /// <summary>
    /// 子物体作为状态
    /// </summary>
    public GameObject[] states;

#if UNITY_EDITOR
    /// <summary>
    /// 编辑器模式下的检查
    /// </summary>
    private void Awake()
    {
        if (states != null)
        {
            foreach(GameObject s in states)
            {
                if (!s.transform.IsChildOf(transform))
                {
                    Debug.LogError("状态机状态必须为其子物体！");
                }
            }
        }
    }
#endif

    //接口------------------------------------
    public void ChangeState(int id)
    {
        if (id >= states.Length)
        {
            Debug.Log("超出状态数量范围！");
            return;
        }
        for(int i = 0; i < states.Length; i++)
        {
            if (i == id) states[i].SetActive(true);
            else states[i].SetActive(false);
        }
    }
}
