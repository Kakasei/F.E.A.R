using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 闪烁的灯 : MonoBehaviour
{
    private float highIntensity = 2f;
    private float lowIntensity = 0;
    public Light alarmLight;
    public float timer = 0;

    void Start()
    {

    }

    void FixedUpdate()
    {
        /*if (alarmOn)
        {
            //alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, targetIntensity, Time.deltaTime * turnSpeed);
            alarmLight.intensity = targetIntensity;
            if (Mathf.Abs(targetIntensity - alarmLight.intensity) <= 0.05f)
            {
                targetIntensity = targetIntensity == highIntensity ? lowIntensity : highIntensity;
                alarmOn = !alarmOn;
            }
        }
        else
        {
            //alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, lowIntensity, Time.deltaTime * turnSpeed);
            alarmLight.intensity = lowIntensity;
            if (alarmLight.intensity < 0.1f)
            {
                alarmLight.intensity = lowIntensity;
                alarmOn = !alarmOn;
            }
        }*/
        timer += Time.deltaTime;
        if (timer%2>1)
        {
            alarmLight.intensity = highIntensity;
        }
        else
        {
            alarmLight.intensity = lowIntensity;
        }
    }
}