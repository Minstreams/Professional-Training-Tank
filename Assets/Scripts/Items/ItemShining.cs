using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自动闪烁
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class ItemShining : MonoBehaviour
{
    private SpriteRenderer sr;

    public float interval = 0.5f;

    private float timer;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        timer = interval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            sr.enabled = !sr.enabled;
            timer = interval;
        }
    }
}
