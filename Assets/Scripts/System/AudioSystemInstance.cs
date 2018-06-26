﻿using System.Collections;
using UnityEngine;

namespace GameSystem
{
    namespace InnerSystem
    {
        namespace Instances
        {
            /// <summary>
            /// 声音系统
            /// </summary>
            [DisallowMultipleComponent]
            [AddComponentMenu("Systems/Audio System")]
            public class AudioSystemInstance : SystemInstance<AudioSystemInstance>
            {
#if UNITY_EDITOR
                [Header("【声音系统】")]
                public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
                public AudioSystem.Setting setting;
            }
        }
    }

    /// <summary>
    /// 声音系统
    /// </summary>
    public static class AudioSystem
    {
        [System.Serializable]
        public class Setting
        {
            [Header("音效音量"), Range(0, 1.0f)]
            public float soundVolumn = 1.0f;

            [Header("音乐音量"), Range(0, 1.0f)]
            public float musicVolumn = 1.0f;

            [Header("音乐淡出时间"), Range(0.1f, 2.0f)]
            public float musicFadeOutTime = 1.0f;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        private static Setting setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        private static InnerSystem.Instances.AudioSystemInstance Instance { get { return InnerSystem.Instances.AudioSystemInstance.Instance; } }


        //变量--------------------------------
        /// <summary>
        /// 用于标记bgm播放器
        /// </summary>
        private static AudioSource musicSource = null;



        //方法--------------------------------
        /// <summary>
        /// 随机播放音效表列里的一个音效
        /// </summary>
        /// <param name="audios">音效表列</param>
        public static void Play(AudioClip[] audios)
        {
            int randomInt = Random.Range(0, audios.Length);
            Instance.StartCoroutine(play(audios[randomInt], Instance));
        }
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="audio">要播放的音效</param>
        public static void Play(AudioClip audio)
        {
            Instance.StartCoroutine(play(audio, Instance));
        }
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="audio">要播放的音效</param>
        /// <param name="source">播放源</param>
        public static void Play(AudioClip audio, MonoBehaviour source)
        {
            source.StartCoroutine(play(audio, source));
        }
        private static IEnumerator play(AudioClip audio, MonoBehaviour source)
        {
            AudioSource _source =
            source.gameObject.AddComponent<AudioSource>();
            _source.clip = audio;
            _source.volume = setting.soundVolumn;
            _source.Play();

            yield return new WaitForSeconds(audio.length);
            MonoBehaviour.Destroy(_source);

            yield return 0;

        }

        /// <summary>
        /// 播放BGM
        /// </summary>
        /// <param name="music"></param>
        public static void PlayMusic(AudioClip music)
        {
            Instance.StartCoroutine(playMusic(music));
        }
        private static IEnumerator playMusic(AudioClip music)
        {
            if (musicSource != null)
            {
                //已有bgm则淡出
                float volumn = setting.musicVolumn;
                while (volumn > 0)
                {
                    musicSource.volume = volumn;
                    volumn -= setting.musicVolumn * Time.deltaTime / setting.musicVolumn;
                    yield return 0;
                }
                MonoBehaviour.Destroy(musicSource);
            }

            if (music == null)
            {
                musicSource = null;
            }
            else
            {
                musicSource = Instance.gameObject.AddComponent<AudioSource>();
                musicSource.clip = music;
                musicSource.volume = setting.musicVolumn;
                musicSource.loop = true;
                musicSource.Play();
            }
            yield return 0;
        }

        /// <summary>
        /// 设置音效音量
        /// </summary>
        /// <param name="volumn">音量（0.0~1.0）</param>
        public static void SetSoundVolumn(float volumn)
        {
            setting.soundVolumn = volumn;
        }

        /// <summary>
        /// 设置音乐音量，并即时应用设置好的音乐音量
        /// </summary>
        /// <param name="volumn">音量（0.0~1.0）</param>
        public static void SetMusicVolumn(float volumn)
        {
            setting.musicVolumn = volumn;
            musicSource.volume = volumn;
        }
    }
}

