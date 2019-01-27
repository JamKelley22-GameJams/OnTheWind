using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light directionalLight;
    public Material skybox;
    public float originalIntensity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Manager.Instance.dayTimer / Manager.Instance.originalDayTimer);
        directionalLight.intensity = originalIntensity * (Manager.Instance.dayTimer / Manager.Instance.originalDayTimer);
        RenderSettings.skybox.SetFloat("_Exposure", (Manager.Instance.dayTimer / Manager.Instance.originalDayTimer));
    }
}
