using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    private int id;

    private ActiveStateMachine asm;

    private void Start()
    {
        asm = GetComponent<ActiveStateMachine>();
        asm.ChangeState(id);
    }
    private void Update()
    {
        if(Input.GetKeyDown(GameSystem.Setter.setting.down)|| Input.GetKeyDown(GameSystem.Setter.setting.down2)|| Input.GetKeyDown(GameSystem.Setter.setting.right)|| Input.GetKeyDown(GameSystem.Setter.setting.right2))
        {
            //下一项
            id++;
            if (id >= 3) id = 0;

            asm.ChangeState(id);
        }
        if(Input.GetKeyDown(GameSystem.Setter.setting.up)|| Input.GetKeyDown(GameSystem.Setter.setting.up2)|| Input.GetKeyDown(GameSystem.Setter.setting.left)|| Input.GetKeyDown(GameSystem.Setter.setting.left2))
        {
            //上一项
            id--;
            if (id < 0) id = 2;

            asm.ChangeState(id);
        }

        if(Input.GetKeyDown(GameSystem.Setter.setting.shoot)|| Input.GetKeyDown(GameSystem.Setter.setting.shoot2)|| Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            switch (id)
            {
                case 0:
                    GameSystem.Setter.setting.isP2On = false;
                    GameSystem.InnerSystem.GameMessageManager.SendGameMessage(GameSystem.InnerSystem.GameMessage.Start);
                    Destroy(this);
                    break;
                case 1:
                    GameSystem.Setter.setting.isP2On = true;
                    GameSystem.InnerSystem.GameMessageManager.SendGameMessage(GameSystem.InnerSystem.GameMessage.Start);
                    Destroy(this);
                    break;
                default:
                    GameSystem.InnerSystem.GameMessageManager.SendGameMessage(GameSystem.InnerSystem.GameMessage.Exit);
                    break;
            }
        }
    }


}
