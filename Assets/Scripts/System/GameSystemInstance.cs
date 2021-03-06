﻿using System.Collections;
using UnityEngine;

namespace GameSystem
{
    namespace InnerSystem
    {
        namespace Instances
        {
            /// <summary>
            /// 游戏系统流程管理实例
            /// </summary>
            [AddComponentMenu("Systems/Game System")]
            public class GameSystemInstance : MonoBehaviour
            {
#if UNITY_EDITOR
                [Header("【游戏系统】")]
                public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
                //编辑器模式下，全局查重，防止有多个游戏系统
                private static GameSystemInstance instance = null;
                private void Awake()
                {
                    if (instance != null)
                    {
                        Debug.LogError("不允许有多个游戏系统！");
                    }
                    instance = this;
                }
                private void Reset()
                {
                    gameObject.tag = "GameController";
                }
#endif
                //游戏启动----------------------------
                private void Start()
                {
                    Cursor.visible = false;
                    StartCoroutine(start());
                }


                //流程--------------------------------
                private void BackToMenu()
                {
                    SceneSystem.PopScene();
                    StopAllCoroutines();
                    Setter.setting.currentScene = 0;
                    StartCoroutine(start());
                }

                private IEnumerator start()
                {
                    SceneSystem.PushScene("StartMenu");

                    //等待上升动画
                    yield return new WaitForSeconds(2);

                    GameMessageManager.ResetGameMessage();
                    while (true)
                    {
                        if (GameMessageManager.GetGameMessage(GameMessage.Start))
                        {
                            break;
                        }
                        if (GameMessageManager.GetGameMessage(GameMessage.Exit))
                        {
                            Application.Quit();
                        }
                        yield return 0;
                    }

                    SceneSystem.ChangeScene("GameTip");
                    StartCoroutine(exitCheck());

                    //等待上升动画
                    yield return new WaitForSeconds(2);

                    GameMessageManager.ResetGameMessage();
                    while (true)
                    {
                        if (GameMessageManager.GetGameMessage(GameMessage.Start))
                        {
                            break;
                        }
                        yield return 0;
                    }

                    ScoreManager.Init();

                    while (Setter.setting.currentScene < Setter.setting.sceneCount)
                    {
                        yield return beforeStart();
                        yield return playScene("scene" + (Setter.setting.currentScene / 10) + (Setter.setting.currentScene % 10));
                        yield return gameWin();
                        Setter.setting.currentScene++;
                    }
                }

                private IEnumerator exitCheck()
                {
                    while (true)
                    {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            BackToMenu();
                            break;
                        }
                        yield return 0;
                    }
                    yield return 0;
                }

                private IEnumerator beforeStart()
                {
                    AudioSystem.Play(Setter.setting.audioStart);
                    SceneSystem.ChangeScene("BeforeStart");
                    yield return new WaitForSeconds(2);
                }

                private IEnumerator playScene(string sceneName)
                {
                    SceneSystem.ChangeScene(sceneName);

                    GameMessageManager.ResetGameMessage();
                    //胜利判定
                    while (true)
                    {
                        yield return 0;
                        if (GameMessageManager.GetGameMessage(GameMessage.Win))
                        {
                            break;
                        }
                        if (GameMessageManager.GetGameMessage(GameMessage.Lose))
                        {
                            yield return gameOver();
                            break;
                        }
                    }
                }

                private IEnumerator gameWin()
                {
                    SceneSystem.ChangeScene("GameWin");

                    //等待上升动画
                    yield return new WaitForSeconds(2);

                    GameMessageManager.ResetGameMessage();
                    while (true)
                    {
                        yield return 0;
                        if (GameMessageManager.GetGameMessage(GameMessage.Start))
                        {
                            break;
                        }
                    }
                    yield return 0;
                }

                private IEnumerator gameOver()
                {
                    SceneSystem.ChangeScene("GameOver");

                    //等待上升动画
                    yield return new WaitForSeconds(2);

                    GameMessageManager.ResetGameMessage();
                    while (true)
                    {
                        yield return 0;
                        if (GameMessageManager.GetGameMessage(GameMessage.Start))
                        {
                            BackToMenu();
                            break;
                        }
                    }
                    yield return 0;
                }

            }

            /// <summary>
            /// 游戏子系统父类
            /// </summary>
            /// <typeparam name="InstanceClass"></typeparam>
            public class SystemInstance<InstanceClass> : MonoBehaviour
            {
                private static InstanceClass instance;
                /// <summary>
                /// 实例
                /// </summary>
                public static InstanceClass Instance
                {
                    get
                    {
                        if (instance == null) instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<InstanceClass>();
                        return instance;
                    }
                }
            }
        }


        /// <summary>
        /// 游戏控制信息枚举
        /// </summary>
        public enum GameMessage
        {
            Start,
            Win,
            Lose,
            Exit
        }

        /// <summary>
        /// 游戏控制消息管理器
        /// 用于提供游戏控制消息接收与查询功能
        /// </summary>
        public static class GameMessageManager
        {
            //游戏控制信息--------------------------------------------

            /// <summary>
            /// 记录游戏控制信息
            /// </summary>
            private static bool[] gameMessageReciver = new bool[System.Enum.GetValues(typeof(GameMessage)).Length];

            /// <summary>
            /// 检查游戏控制信息，收到则返回true
            /// </summary>
            /// <param name="message">要检查的信息</param>
            /// <param name="reset">是否在接收后重置</param>
            /// <returns>检查按钮信息，收到则返回true</returns>
            public static bool GetGameMessage(GameMessage message, bool reset = true)
            {
                if (gameMessageReciver[(int)message])
                {
                    if (reset) gameMessageReciver[(int)message] = false;
                    return true;
                }
                return false;
            }
            /// <summary>
            /// 发送 游戏控制信息
            /// </summary>
            /// <param name="message">信息</param>
            public static void SendGameMessage(GameMessage message)
            {
                gameMessageReciver[(int)message] = true;
                Debug.Log(message + " sended!");
            }
            /// <summary>
            /// 重置
            /// </summary>
            public static void ResetGameMessage()
            {
                for (int i = 0; i < gameMessageReciver.Length; i++)
                {
                    gameMessageReciver[i] = false;
                }
            }


            //游戏控制事件--------------------------------------------



        }
    }
}

#if UNITY_EDITOR
[System.Serializable]
public struct EmptyStruct { }
#endif


namespace GameSystem
{
    /// <summary>
    /// 阵营类型
    /// </summary>
    public enum CampFlag
    {
        player,
        enemy
    }
}