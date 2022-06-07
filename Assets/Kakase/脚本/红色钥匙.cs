using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 红色钥匙 : 道具
{
    public 捡钥匙触发血手印 捡钥匙触发血手印_脚本;
    private AudioSource 音频源;


    public override void 拾取后触发()
    {
        base.拾取后触发();
        音频源.Play();
        捡钥匙触发血手印_脚本.触发血手印();
    }
}