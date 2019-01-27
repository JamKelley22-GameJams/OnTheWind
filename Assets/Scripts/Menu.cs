using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject _title;
    public GameObject _team;
    public AudioSource _audio;
    public AudioClip _clip;

    public Slider _slider;

    public void LoadScene()
    {
        _audio.clip = _clip;
        _audio.Play();
        SceneManager.LoadScene("GameplayTestLevel");
    }

    public void Settings()
    {
        _audio.clip = _clip;
        _audio.Play();
    }

    public void Credits()
    {
        _audio.clip = _clip;
        _audio.Play();
    }

    public void Quit()
    {
        _audio.clip = _clip;
        _audio.Play();
        Application.Quit();
    }

    public void Disable()
    {
        _title.SetActive(false);
        _team.SetActive(false);
    }

    public void FullScreen()
    {
        _audio.clip = _clip;
        _audio.Play();
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void Update()
    {
        AudioListener.volume = _slider.value;
    }

    public void Back()
    {
        _audio.clip = _clip;
        _audio.Play();
    }
}
