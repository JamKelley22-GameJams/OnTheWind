using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using System;

/*
 * Class to hold all the necessary settings through all of the scenes, Present from begining to end of game
 */
public class GameSettings : MonoBehaviour
{
    private static GameSettings _instance;
    public static GameSettings Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void Start()
    {
        keyBindings = new Dictionary<string, string>();

        CheckFirstRun();
    }

    private Dictionary<string, string> keyBindings;

    private bool _sfxOn = true;
    private bool firstRun;
    public bool IsSpraying { get; set; }
    public float Volume
    {
        get
        {
            float vol;
            audioMixer.GetFloat("attenuation", out vol);
            return vol;
        }
    }
    private AudioMixer audioMixer;

    /*
	 * Getter/Setter for SFX status (allowed to play or not)
	 */
    public bool SFX
    {
        get { return _sfxOn; }
        set { _sfxOn = value; }
    }

    /*
	 * Setter for Sim Volume
	 */
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("attenuation", volume);
    }

    /*
	 * Getter for FirstRun status (allowed to play or not)
	 */
    public bool getFirstRun()
    {
        return this.firstRun;
    }

    void CheckFirstRun()
    {
        int FALSE = 0;
        int TRUE = 1;
        int val = PlayerPrefs.GetInt("FirstRun", TRUE);//1 when first
        this.firstRun = (val == TRUE) ? true : false;
        if (this.firstRun)
        {
            PlayerPrefs.SetInt("FirstRun", FALSE);
            //Debug.Log("First Run");
        }
        else
        {
            //Debug.Log("Not First Run");
        }
    }
}