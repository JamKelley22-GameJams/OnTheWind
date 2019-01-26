using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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
}
