using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLighSystem : MonoBehaviour
{
    [SerializeField] private float lightDecay = .1f;
    [SerializeField] private float angleDecay = 1f;
    [SerializeField] private float minAngle = 40f;

    private Light myFlashLight;

    private void Start()
    {
        myFlashLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecraseLightAngle();
        DecraseLightIntensity();
    }

    private void DecraseLightIntensity()
    {
        myFlashLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecraseLightAngle()
    {
        if (myFlashLight.spotAngle <= minAngle)
        {
            return;
        }
        else
        {
            myFlashLight.spotAngle -= angleDecay * Time.deltaTime;
        }

    }
}
