using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public interface ISound : IPoolable
{
    public SoundType SOUNDTYPE { get; set; }
    public AudioClip AUDIOCLIP { get; set; }

    public void Init(SoundType soundType ,AudioClip audioClip);

    public void PlaySound();
    public void StopSound();

    public void SoundSetVolume(float volume=1f);
    public void SoundSetMute(bool isMute = true);
    public void SoundSetLoop(bool isLoop = false);
}
