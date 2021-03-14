using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource source;
    public static SoundManager speaker;
    void Awake()
    {
        speaker = this;
        source = this.GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound){
        source.PlayOneShot(sound);
    }

    
}
