using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvlUI : MonoBehaviour
{
    public AudioSource _audio;
    public AudioClip _clip;

    public void NextLvl()
    {
        _audio.clip = _clip;
        _audio.Play();
        SceneManager.LoadScene("GameplayTestScene");
    }
}
