using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : AmmoDetector
{
	public static Vector3 position;
	private void Start()
	{
		position = transform.position;
	}
	protected override void Hit(Ammo ammo)
    {
        ammo.Boom();
        GameSystem.InnerSystem.GameMessageManager.SendGameMessage(GameSystem.InnerSystem.GameMessage.Lose);
    }
}
