using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMover : MonoBehaviour {
    public Vector3 offset;
    public float time;

    private float timer;

    private void Start()
    {
        timer = time;
        transform.Translate(-offset);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) Destroy(this);
        transform.Translate(offset * Time.deltaTime / time);
    }
}
