using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light directionalLight;
    public Skybox skybox;
    public float originalIntensity;
    public float originalExposure;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dayInterp = (Manager.Instance.dayTimer / Manager.Instance.originalDayTimer);
        directionalLight.intensity = originalIntensity * dayInterp;
        RenderSettings.skybox.SetFloat("_Exposure", Mathf.Clamp(originalExposure * dayInterp - 0.15f, 0.4f, 3.0f));
        RenderSettings.skybox.SetColor("_SkyTint", new Color(1.0f * dayInterp, 1.0f * dayInterp, 1.0f * dayInterp));
    }
}
