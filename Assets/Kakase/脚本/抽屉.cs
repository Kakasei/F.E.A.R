using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 抽屉 : 道具
{
    private Transform 起点;
    private Transform 终点;
    private int 状态;

    public float 开关速度;

    private void Awake()
    {
        状态 = 1;

        起点 = GetComponentsInChildren<Transform>()[0];
        终点 = GetComponentsInChildren<Transform>()[1];

    }

    public override void 交互后触发()
    {
        base.交互后触发();

    }

    private void FixedUpdate()
    {

    }



}
