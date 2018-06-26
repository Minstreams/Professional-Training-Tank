using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

public class PlayerCore2 : Comp
{
    private void Update()
    {
        if (Input.GetKeyDown(Setter.setting.shoot2))
        {
            tank.Shoot();
        }
        if (Input.GetKey(Setter.setting.up2))
        {
            tank.Drive(Vector3.up);
        }
        else if (Input.GetKey(Setter.setting.down2))
        {
            tank.Drive(Vector3.down);
        }
        else if (Input.GetKey(Setter.setting.left2))
        {
            tank.Drive(Vector3.left);
        }
        else if (Input.GetKey(Setter.setting.right2))
        {
            tank.Drive(Vector3.right);
        }
    }
}
