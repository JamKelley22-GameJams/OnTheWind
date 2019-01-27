using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public static SoundFX _instance;

    public AudioSource _audio;
    public AudioClip _clip;

    public void PlayAudio()
    {
        _audio.clip = _clip;
        _audio.Play();
    }
}
