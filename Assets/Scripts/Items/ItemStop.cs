using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStop : Item
{
    protected override void BuffOff(Tank tank)
    {
        Tank[] t = GameObject.Find("EnemySpawner").GetComponentsInChildren<Tank>();

        foreach (Tank tk in t)
        {
            tk.driver.Conti();
            tk.shooter.Conti();
        }
    }

    protected override void BuffOn(Tank tank)
    {
        Tank[] t = GameObject.Find("EnemySpawner").GetComponentsInChildren<Tank>();

        foreach (Tank tk in t)
        {
            tk.driver.Stop();
            tk.shooter.Stop();
        }
    }
}
