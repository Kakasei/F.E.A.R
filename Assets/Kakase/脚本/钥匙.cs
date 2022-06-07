using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class 钥匙 : 道具
{
    private AudioSource 音频源;


    private void Awake()
    {
        音频源 = GetComponent<AudioSource>();
    }

    public override void 拾取后触发()
    {
        base.拾取后触发();
        音频源.Play();
    }


}
