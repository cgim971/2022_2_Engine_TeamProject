using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager
{
    public enum SoundType
    {
        BGM,
        SAMPLE,
        END
    }

    public static Dictionary<string, AudioClip> soundClipDictionary = new Dictionary<string, AudioClip>();
    public static Dictionary<string, GameObject> soundObjectDictionary = new Dictionary<string, GameObject>();

    public static void Init()
    {
        try
        {
            GameObject root = GameObject.Find("@Sound");
            if (root == null)
            {
                throw new Exception("Could not find \"@Sound\"");
            }

            PoolingManager.CreatePool("SoundObject", root.transform, (int)SoundType.END);

            for (SoundType soundType = SoundType.BGM; soundType < SoundType.END; soundType++)
            {
                GameObject obj = PoolingManager.PopObject("SoundObject", false);
                AudioClip audioClip = null;

                if (soundClipDictionary.ContainsKey(soundType.ToString()))
                {
                    audioClip = soundClipDictionary[soundType.ToString()];
                }
                else
                {
                    audioClip = Resources.Load<AudioClip>($"Sounds/{soundType}");

                    if (audioClip != null)
                    {
                        soundClipDictionary.Add(soundType.ToString(), audioClip);
                    }
                    else
                    {
                        throw new Exception("Could not find AudioClip");
                    }
                }

                ISound sound = obj.GetComponent<ISound>();
                sound.Init(soundType, audioClip);

                if (!soundObjectDictionary.ContainsKey(soundType.ToString()))
                {
                    soundObjectDictionary.Add(soundType.ToString(), obj);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return;
        }
    }

    public static void PlaySound(SoundType soundType)
    {
        if (soundObjectDictionary.ContainsKey(soundType.ToString()))
        {
            GameObject soundObj = soundObjectDictionary[soundType.ToString()];
            ISound sound = soundObj.GetComponent<ISound>();
            sound.PlaySound();
        }
    }

    public static void StopSound(SoundType soundType)
    {
        if (soundObjectDictionary.ContainsKey(soundType.ToString()))
        {
            GameObject soundObj = soundObjectDictionary[soundType.ToString()];
            ISound sound = soundObj.GetComponent<ISound>();
            sound.StopSound();
        }
    }

    public static void SetVolume(float volume = 1f)
    {
        PlayerPrefs.SetFloat("SoundVolume", volume);

        foreach (GameObject soundObj in soundObjectDictionary.Values)
        {
            ISound sound = soundObj.GetComponent<ISound>();
            sound.SoundSetVolume(volume);
        }
    }
}
