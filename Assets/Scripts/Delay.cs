using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public AudioSource _jukebox;

    public void DelayPiano()
    {
        _jukebox.Play();
    }
}
