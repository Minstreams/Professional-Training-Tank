using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoom : Item
{
    protected override void BuffOff(Tank tank)
    {
    }

    protected override void BuffOn(Tank tank)
    {
        Tank[] t =
        GameObject.Find("EnemySpawner").GetComponentsInChildren<Tank>();

        foreach(Tank tk in t)
        {
            tk.Boom();
        }
    }
}
