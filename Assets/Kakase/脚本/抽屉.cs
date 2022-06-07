using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class 抽屉 : 道具
{
    public Transform 起点;
    public Transform 终点;
    private int 状态;

    private AudioSource 音频源;

    public float 开关速度;

    private void Awake()
    {
        音频源 = GetComponent<AudioSource>();

        状态 = 1;
    }

    public override void 交互后触发()
    {
        音频源.Play();
        if (状态 == 1)
        {
            状态 = 0;
        }
        else if (状态 == 0)
        {
            状态 = 1;
        }
        Debug.Log(终点.ToString());
        Debug.Log(起点.ToString());
    }

    private void FixedUpdate()
    {
        if(状态==0)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, 终点.position, Time.deltaTime * 开关速度);
        }
        else if(状态==1)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, 起点.position, Time.deltaTime * 开关速度);
        }
    }



}
