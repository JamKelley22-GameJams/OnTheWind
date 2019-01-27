using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _player;
    public GameObject _sunMoonCanvas;
    public GameObject _cam;
    public AudioSource _audio;
    public AudioClip _clip;
    public AudioClip _clip2;

    public Animator _sunAnimator;
    public Animator _moonAnimaotr;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _pauseMenu.activeInHierarchy == false)
        {
            _player.GetComponent<Rigidbody>().isKinematic = true;

            _cam.GetComponent<DandelionCameraController>().enabled = false;

            _pauseMenu.SetActive(true);
            
            _sunAnimator.GetComponent<Animation>().name = "SunAnim";

            _sunAnimator.speed = 0;

            _moonAnimaotr.GetComponent<Animation>().name = "MoonAnim";

            _moonAnimaotr.speed = 0;

            _audio.clip = _clip;
            _audio.Play();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && _pauseMenu.activeInHierarchy == true)
        {
            _player.GetComponent<Rigidbody>().isKinematic = false;

            _cam.GetComponent<DandelionCameraController>().enabled = true;

            _pauseMenu.SetActive(false);

            _sunAnimator.GetComponent<Animation>().name = "SunAnim";

            _sunAnimator.speed = 1;

            _moonAnimaotr.GetComponent<Animation>().name = "MoonAnim";

            _moonAnimaotr.speed = 1;

            _audio.clip = _clip2;
            _audio.Play();
        }
    }
}
