using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public enum SoundType
    {
        NONE,
        SOUNDOBJECT,
    }

    public static Dictionary<string, AudioClip> audioDictionary = new Dictionary<string, AudioClip>();
    public static Dictionary<string, GameObject> audioObjectDictionary = new Dictionary<string, GameObject>();

    private static string SOUNDOBJECT = "SoundObject";

    public static void CreateAudio(string name, Transform parent = null, SoundType type = SoundType.NONE)
    {
        if (!PoolingManager.PooledCheck(SOUNDOBJECT)) PoolingManager.CreatePool(SOUNDOBJECT, parent);

        AudioClip audioClip = null;
        if (!audioDictionary.ContainsKey(name))
        {
            audioClip = Resources.Load<AudioClip>($"Sounds/{name}");
            audioDictionary.Add(name, audioClip);
        }
        else
        {
            audioClip = audioDictionary[name];
        }

        GameObject newSoundObj = PoolingManager.PopObject(SOUNDOBJECT);
        switch (type)
        {
            case SoundType.SOUNDOBJECT:
                newSoundObj.AddComponent<SoundObject>();
                break;
        }

        newSoundObj.GetComponent<SoundObject_Base>().AUDIOSOURCE.clip = audioClip;

        audioObjectDictionary.Add(name, newSoundObj);
    }

    public static void PlayAudio(string name)
    {
        if (!audioObjectDictionary.ContainsKey(name)) CreateAudio(name);

        audioObjectDictionary[name].GetComponent<ISound>().PlaySound();
    }

    public static void StopAudio(string name)
    {
        if (!audioObjectDictionary.ContainsKey(name)) CreateAudio(name);

        audioObjectDictionary[name].GetComponent<ISound>().StopSound();
    }

}
