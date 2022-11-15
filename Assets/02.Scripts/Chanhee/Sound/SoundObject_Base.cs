using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObject_Base : MonoBehaviour, IPoolable, ISound
{
    AudioSource audioSource;
    public AudioSource AUDIOSOURCE { get => audioSource; set => audioSource = value; }


    private string objName;
    public string NAME { get => objName; set => objName = value; }


    private void Awake() => audioSource = GetComponent<AudioSource>();


    public virtual void PlaySound() => audioSource.Play();
    public virtual void StopSound() => audioSource.Stop();


    public void OnPool() => audioSource.playOnAwake = false;
    public void PushObj() => PoolingManager.PushObject(objName, this.gameObject);
}
