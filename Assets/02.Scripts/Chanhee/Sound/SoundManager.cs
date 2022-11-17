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

    public static Dictionary<string, AudioClip> soundClipDictionary = new Dictionary<string, AudioClip>();
    public static Dictionary<SoundType, AudioSource> soundTypeDictionary = new Dictionary<SoundType, AudioSource>();

    static GameObject root = null;
    static GameObject soundObject = null;

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
            root = GameObject.Find("@Sound");
            if (root == null)
            {
                throw new Exception("Could not find \"@Sound\"");
            }

            soundObject = Resources.Load<GameObject>("Prefabs/SoundObject");
            if (soundObject == null)
            {
                throw new Exception("Could not find \"SoundObject\"");
            }

            CreateSound(SetSoundInfo("BGM", SoundType.BGM));
            CreateSound(SetSoundInfo("EFFECTS", SoundType.EFFECT, false));

            SoundPlay("BGM", SoundType.BGM);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return;
        }
    }

    public static void CreateSound(SoundInfo soundInfo)
    {
        Transform soundParent = root.transform;
        string soundName = soundInfo.soundName;

        GameObject newSoundObj = GameObject.Instantiate(soundObject, soundParent);
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

        // AudioSource ¼³Á¤
        sound.playOnAwake = false;


        if (!soundTypeDictionary.ContainsKey(soundInfo.soundType))
        {
            soundTypeDictionary.Add(soundInfo.soundType, sound);
        }
    }

    public static AudioClip SoundClip(string soundName)
    {
        AudioClip clip = null;
        if (soundClipDictionary.ContainsKey(soundName))
        {
            clip = soundClipDictionary[soundName];
        }
        else
        {
            clip = Resources.Load<AudioClip>($"Sounds/{soundName}");
            if (clip == null)
            {
                throw new Exception("Could not find clip");
            }
            soundClipDictionary.Add(soundName, clip);
        }

        return clip;
    }

    public static void SoundPlay(string soundName, SoundType soundType)
    {
        try
        {
            if (soundTypeDictionary.ContainsKey(soundType))
            {
                AudioSource sound = soundTypeDictionary[soundType];
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
            if (soundTypeDictionary.ContainsKey(soundType))
            {
                AudioSource sound = soundTypeDictionary[soundType];
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
