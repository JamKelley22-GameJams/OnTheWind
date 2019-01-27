using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _player;
    public GameObject _sunMoonCanvas;
    public GameObject _cam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && _pauseMenu.activeInHierarchy == false)
        {
            _player.GetComponent<Rigidbody>().isKinematic = true;

            _cam.GetComponent<DandelionCameraController>().enabled = false;
            
            _pauseMenu.SetActive(true);
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && _pauseMenu.activeInHierarchy == true)
        {
            _player.GetComponent<Rigidbody>().isKinematic = false;

            _cam.GetComponent<DandelionCameraController>().enabled = true;

            _pauseMenu.SetActive(false);
        }
    }
}
