using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 道具生成器
/// </summary>
public class ItemSpawner : MonoBehaviour
{
    public Vector2 xRange;
    public Vector2 yRange;

    public Vector2 timeInteval;
    public float timeLast;

    private float timer;

    public GameObject[] items;

    private void Start()
    {
        timer = Random.Range(timeInteval.x, timeInteval.y);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(timeInteval.x, timeInteval.y);
            GenerateItem();
        }
    }
    private void GenerateItem()
    {
        StartCoroutine(generateItem());
    }

    private IEnumerator generateItem()
    {
        GameObject g =
        GameObject.Instantiate(items[Random.Range(0, items.Length)], new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 0), Quaternion.identity, transform);
        yield return new WaitForSeconds(timeLast);
        if (g != null) Destroy(g);
    }
}
