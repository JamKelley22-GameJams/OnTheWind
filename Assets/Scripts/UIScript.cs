using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
	public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel("MainMenu1");
    }
}
