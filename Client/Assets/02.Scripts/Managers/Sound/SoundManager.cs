using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager
{
    public enum SoundType
    {
        NONE,
        BGM,
        EFFECT,
    }

    public struct SoundInfo
    {
        public string soundName;
        public SoundType soundType;
        public bool isSound;
    }

    public static Dictionary<string, AudioClip> _soundClipDictionary = new Dictionary<string, AudioClip>();
    public static Dictionary<SoundType, AudioSource> _soundTypeDictionary = new Dictionary<SoundType, AudioSource>();

    public static GameObject _root = null;
    public static GameObject _soundObject = null;

    public static SoundInfo SetSoundInfo(string soundName, SoundType soundType, bool isSound = true)
    {
        SoundInfo info = new SoundInfo
        {
            soundName = soundName,
            soundType = soundType,
            isSound = isSound
        };

        return info;
    }

    public static void Init()
    {
        try
        {
            _root = GameObject.Find("@Sound");
            if (_root == null)
            {
                _root = new GameObject { name = "@Sound" };
            }

            _soundObject = new GameObject { name = "SoundObject" };

            CreateSound(SetSoundInfo("BGM", SoundType.BGM));
            CreateSound(SetSoundInfo("EFFECTS", SoundType.EFFECT, false));

            // 배경음 시작
            //SoundPlay("BGM", SoundType.BGM);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return;
        }
    }

    public static void CreateSound(SoundInfo soundInfo)
    {
        Transform soundParent = _root.transform;
        string soundName = soundInfo.soundName;

        GameObject newSoundObj = GameObject.Instantiate(_soundObject, soundParent);
        newSoundObj.name = soundName;

        AudioSource sound = newSoundObj.AddComponent<AudioSource>();
        if (soundInfo.isSound == true)
        {
            AudioClip clip = SoundClip(soundName);
            sound.clip = clip;
        }

        if (soundInfo.soundType == SoundType.BGM)
        {
            sound.loop = true;
        }

        // AudioSource 설정
        sound.playOnAwake = false;


        if (!_soundTypeDictionary.ContainsKey(soundInfo.soundType))
        {
            _soundTypeDictionary.Add(soundInfo.soundType, sound);
        }
    }

    public static AudioClip SoundClip(string soundName)
    {
        AudioClip clip = null;
        if (_soundClipDictionary.ContainsKey(soundName))
        {
            clip = _soundClipDictionary[soundName];
        }
        else
        {
            clip = Resources.Load<AudioClip>($"Sounds/{soundName}");
            if (clip == null)
            {
                throw new Exception("Could not find clip");
            }
            _soundClipDictionary.Add(soundName, clip);
        }

        return clip;
    }

    public static void SoundPlay(string soundName, SoundType soundType)
    {
        try
        {
            if (_soundTypeDictionary.ContainsKey(soundType))
            {
                AudioSource sound = _soundTypeDictionary[soundType];
                if (sound == null)
                {
                    throw new Exception("Could not find AudioSource");
                }
                sound.clip = SoundClip(soundName);

                if (soundType == SoundType.BGM)
                {
                    if (sound.isPlaying)
                    {
                        sound.Stop();
                    }

                    sound.Play();
                    return;
                }
                else if (soundType == SoundType.EFFECT)
                {
                    sound.PlayOneShot(sound.clip);
                }
            }
            else
            {
                throw new Exception("Counld not find Dictionary - SoundType");
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public static void SoundStop(SoundType soundType)
    {
        try
        {
            if (_soundTypeDictionary.ContainsKey(soundType))
            {
                AudioSource sound = _soundTypeDictionary[soundType];
                if (sound.isPlaying)
                    sound.Stop();
            }
            else
            {
                throw new Exception("Counld not find Dictionary - SoundType");
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

}
