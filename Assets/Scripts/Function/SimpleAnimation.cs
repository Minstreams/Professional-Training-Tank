using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 简单动画
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[AddComponentMenu("Function/Simple Animation")]
public class SimpleAnimation : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite[] sprites;
    public float interval = 0.1f;

    private float timer;
    private int id;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        id = 0;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            sr.sprite = sprites[id];
            id++;
            if (id >= sprites.Length) id = 0;
            timer = interval;
        }
    }
}
