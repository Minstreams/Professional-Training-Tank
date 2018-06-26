using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

public class PlayerCore : Comp
{
    private void Update()
    {
        if (Input.GetKeyDown(Setter.setting.shoot))
        {
            tank.Shoot();
        }
        if (Input.GetKey(Setter.setting.up))
        {
            tank.Drive(Vector3.up);
        }
        else if (Input.GetKey(Setter.setting.down))
        {
            tank.Drive(Vector3.down);
        }
        else if (Input.GetKey(Setter.setting.left))
        {
            tank.Drive(Vector3.left);
        }
        else if (Input.GetKey(Setter.setting.right))
        {
            tank.Drive(Vector3.right);
        }
    }
}
