using System.Collections;
using UnityEngine;

namespace GameSystem
{
    namespace InnerSystem
    {
        namespace Instances
        {
            /// <summary>
            /// 系统参数设置器
            /// </summary>
            [DisallowMultipleComponent]
            [AddComponentMenu("Systems/Setter")]
            public class SetterInstance : SystemInstance<SetterInstance>
            {
#if UNITY_EDITOR
                [Header("【系统参数设置器】")]
                public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
                public Setter.Setting setting;
            }
        }
    }

    /// <summary>
    /// 系统参数设置器
    /// </summary>
    public static class Setter
    {
        [System.Serializable]
        public class Setting
        {
            [Header("Prefab")]
            public GameObject ammoPrefab;
            public GameObject boomPrefab;
            public GameObject boomSlight;
            public GameObject ammoWallArea;
            public GameObject spwanStar;
            [Header("参数")]
            [Range(1, 100)]
            public int MaxAmmoNum;
            public int sceneCount;
            public int currentScene;
            public float ammoSpeed;
            public bool isP2On;
            [Header("按键")]
            public KeyCode up;
            public KeyCode down;
            public KeyCode left;
            public KeyCode right;
            public KeyCode shoot;
            [Header("----------")]
            public KeyCode up2;
            public KeyCode down2;
            public KeyCode left2;
            public KeyCode right2;
            public KeyCode shoot2;
            [Header("音效")]
            public AudioClip audioStart;
            public AudioClip audioFire;
            public AudioClip audioHit;
            public AudioClip audioBlast;
            public AudioClip audioAdd;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        public static Setting setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        private static InnerSystem.Instances.SetterInstance Instance { get { return InnerSystem.Instances.SetterInstance.Instance; } }
    }
}

