using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    public UIManager _ui;

    public GameObject _player;
    public GameObject _cam;
    //public GameObject _lvlEndedCanvas;
    //public Animator _timesUp;
    public GameObject _timesUp;
    public GameObject _levelEnded;
    public GameObject _waterCollected;
    public GameObject _waterNum;
    public GameObject _nextDay;

    public void StopLevel()
    {
        _timesUp.GetComponent<Animator>().Play("TimesUp");
        StartCoroutine("slowPlayerCam");
    }

    IEnumerator slowPlayerCam()
    {
        yield return new WaitForSeconds(2f);
        _timesUp.SetActive(false);
        _player.GetComponent<Rigidbody>().isKinematic = true;
        _cam.GetComponent<DandelionCameraController>().enabled = false;
        _levelEnded.SetActive(true);
        _waterNum.SetActive(true);
        _waterCollected.SetActive(true);
        _nextDay.SetActive(true);
    }
}
