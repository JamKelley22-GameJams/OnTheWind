using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject _title;
    public GameObject _team;

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
}
