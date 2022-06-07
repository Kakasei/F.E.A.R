using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 可旋转的家具 : 道具
{
    public Transform 起点;
    public Transform 终点;
    private int 状态;

    public float 开关速度=2.0f;

    private void Start()
    {
        状态 = 1;

    }

    public override void 交互后触发()
    {
        if (状态 == 1)
        {
            状态 = 0;
        }
        else if (状态 == 0)
        {
            状态 = 1;
        }
    }

    private void FixedUpdate()
    {
        if (状态 == 0)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, 终点.rotation, Time.deltaTime * 开关速度);
        }
        else if (状态 == 1)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, 起点.rotation, Time.deltaTime * 开关速度);
        }
    }

}
