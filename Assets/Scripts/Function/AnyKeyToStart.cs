using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.InnerSystem;

public class AnyKeyToStart : MonoBehaviour {
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            GameMessageManager.SendGameMessage(GameMessage.Start);
        }
    }
}
