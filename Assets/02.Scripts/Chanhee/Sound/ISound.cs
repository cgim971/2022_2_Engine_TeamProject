using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISound
{
    public AudioSource AUDIOSOURCE { get; set; }
    public string NAME { get; set; }

    public void PlaySound();
    public void StopSound();
}
