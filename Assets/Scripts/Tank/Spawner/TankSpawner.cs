using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 坦克生成器
/// </summary>
public abstract class TankSpawner : MonoBehaviour
{
    [Header("【坦克生成器】")]
    [Header("生成点")]
    public Transform[] spwanPoints;

    [Header("主要类型")]
    public GameObject mainTank;

    [Header("稀有类型和概率")]
    public rareTank[] rareTanks;

    [System.Serializable]
    public struct rareTank
    {
        public GameObject prefab;
        [Header("生成率（0-1）"), Range(0, 1)]
        public float rate;
    }

#if UNITY_EDITOR
    protected virtual void Awake()
    {
        if (spwanPoints == null)
        {
            Debug.LogError("必须要有SpwanPoint！");
        }
        if (rareTanks != null)
        {
            float sum = 0;
            foreach (rareTank rt in rareTanks)
            {
                if(rt.prefab == null)
                {
                    Debug.LogError("出生点没有设置！");
                }
                sum += rt.rate;
            }
            if (sum >= 1)
            {
                Debug.LogError("稀有坦克几率之和不能大于1");
            }
        }
    }
#endif

    /// <summary>
    /// 随机获取一个坦克
    /// </summary>
    /// <returns></returns>
    private GameObject GetATank()
    {
        if (rareTanks != null)
        {
            float rate = Random.value;
            for (int i = 0; i < rareTanks.Length; i++)
            {
                if (rate < rareTanks[i].rate)
                {
                    return rareTanks[i].prefab;
                }
                rate -= rareTanks[i].rate;
            }
        }
        return mainTank;
    }

    //接口-----------------------------------
    public void GenerateTank()
    {
        StartCoroutine(generateTank());
    }

    private IEnumerator generateTank()
    {
        Transform spawnPoint = spwanPoints[Random.Range(0, spwanPoints.Length)];
        GameObject g = GameObject.Instantiate(GameSystem.Setter.setting.spwanStar, spawnPoint.position, Quaternion.identity, transform);
        yield return new WaitForSeconds(2);
        Destroy(g);

        g = GameObject.Instantiate(GetATank(), spawnPoint.position, Quaternion.identity, transform);
        g.GetComponent<Tank>().onDie += OnTankDie;
        OnTankSpwan(g.GetComponent<Tank>());
    }

    /// <summary>
    /// 坦克阵亡时调用
    /// </summary>
    /// <param name="value"></param>
    protected abstract void OnTankDie(int value);

    /// <summary>
    /// 坦克生成时调用
    /// </summary>
    /// <param name="tank">生成的坦克类型</param>
    protected abstract void OnTankSpwan(Tank tank);
}
