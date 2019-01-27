using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject _title;
    public GameObject _team;

    public Slider _slider;

    public void LoadScene()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Settings()
    {

    }

    public void Credits()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Disable()
    {
        _title.SetActive(false);
        _team.SetActive(false);
    }

    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void Update()
    {
        AudioListener.volume = _slider.value;
    }
}
