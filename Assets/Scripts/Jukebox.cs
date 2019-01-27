using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(AudioSource))]
    public class Jukebox : MonoBehaviour
    {
        public AudioClip _song1;
        public AudioClip _song2;

        IEnumerator Start()
        {
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();
            //yield return new WaitForSeconds(audio.clip.length);
            audio.clip = _song1;
            audio.Play();

            if(audio.clip.length == 1)
            {
                audio.clip = _song2;
                audio.Play();
            }

            if(audio.clip.length == 1)
            {
                audio.clip = _song1;
                audio.Play();
            }

        yield return new WaitForSeconds(0f);
        }
    }
