using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 与子弹检测碰撞
/// </summary>
[RequireComponent(typeof(Collider))]
public abstract class AmmoDetector : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ammo")
        {
            Hit(collision.gameObject.GetComponent<Ammo>());
        }
    }

    protected abstract void Hit(Ammo ammo);
}
