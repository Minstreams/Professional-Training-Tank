using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动态子弹管理
/// </summary>
public class AmmoManager : MonoBehaviour
{
    private static AmmoManager instance;


    /// <summary>
    /// 子弹预设
    /// </summary>
    private static GameObject ammoPrefab { get { return GameSystem.Setter.setting.ammoPrefab; } }

    /// <summary>
    ///子弹表
    /// </summary>
    private static List<GameObject> ammos = new List<GameObject>();

    private void Start()
    {
        idActive = new bool[GameSystem.Setter.setting.MaxAmmoNum];
        instance = this;
        foreach (GameObject a in ammos)
        {
            if (a != null) Destroy(a);
        }
        ammos.Clear();
    }

    private static int id = 0;
    private bool[] idActive;
    public static int GetId()
    {
        if (id >= GameSystem.Setter.setting.MaxAmmoNum) id = 0;
        return id++;
    }
    public static void GenerateAmmo(Vector3 pos, Vector3 direction, float speed, int id, GameSystem.CampFlag camp)
    {
        if (!instance.idActive[id]) instance.StartCoroutine(instance.generateAmmo(pos, direction, speed, id, camp));
    }

    private IEnumerator generateAmmo(Vector3 pos, Vector3 direction, float speed, int id, GameSystem.CampFlag camp)
    {
        idActive[id] = true;

        GameSystem.AudioSystem.Play(GameSystem.Setter.setting.audioFire);
        GameObject ammo = GameObject.Instantiate(ammoPrefab, pos, Quaternion.LookRotation(Vector3.forward, direction), instance.transform);
        ammo.GetComponent<Ammo>().campFlag = camp;

        //ammo.GetComponent<Rigidbody>().velocity = direction * speed;

        while (ammo != null)
        {
            ammo.transform.Translate(Vector3.up * Time.deltaTime * speed);
            yield return 0;
        }

        idActive[id] = false;
        yield return 0;
    }

}
