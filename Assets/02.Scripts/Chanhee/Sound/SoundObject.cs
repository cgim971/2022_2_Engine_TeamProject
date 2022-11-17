using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class SoundObject : MonoBehaviour, ISound
{
    private string objName;
    public string NAME { get => objName; set => objName = value; }

    private SoundType soundType;
    public SoundType SOUNDTYPE { get => soundType; set => soundType = value; }

    private AudioSource audioSource;
    public AudioClip AUDIOCLIP { get => audioSource.clip; set => audioSource.clip = value; }


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void Init(SoundType soundType, AudioClip audioClip)
    {
        this.soundType = soundType;
        this.audioSource.clip = audioClip;

        SoundSetVolume();
        SoundSetMute();

        if (soundType == SoundType.BGM)
            SoundSetLoop(true);
        else
            SoundSetLoop();
    }

    public void OnPool() { }
    public void PushObj() { PoolingManager.PushObject(objName, this.gameObject); }


    public void PlaySound() => audioSource.Play();
    public void StopSound() => audioSource.Stop();

    public void SoundSetVolume(float volume = 1f)
    {
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            volume = PlayerPrefs.GetFloat("SoundVolume", volume);
        }
        else
        {
            PlayerPrefs.SetFloat("SoundVolume", volume);
        }
        audioSource.volume = volume;
    }
    public void SoundSetMute(bool isMute = false)
    {
        int mute = isMute == true ? 1 : 0;
        if (PlayerPrefs.HasKey("SoundMute"))
        {
            mute= PlayerPrefs.GetInt("SoundMute", mute);
        }
        else
        {
            PlayerPrefs.SetInt("SoundMute", mute);
        }
        isMute = mute == 1 ? true : false;
        audioSource.mute = isMute;
    }
    public void SoundSetLoop(bool isLoop = false) => audioSource.loop = isLoop;
}
