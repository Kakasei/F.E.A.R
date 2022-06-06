using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 可旋转的家具 : 道具
{
    private Vector3 开;

    private Quaternion 关;
    private int 状态;

    public float 旋转速度;
    [Header("旋转角度")]
    public float x;
    public float y;
    public float z;

    private void Start()
    {
        状态 = 1;

        关 = this.transform.rotation;
        开 = new Vector3(x, y, z);
    }

    public override void 交互后触发()
    {
        Debug.Log(this.transform.rotation);
        if(状态==1)
        {
            状态 = 0;
        }else if(状态==0)
        {
            状态 = 1;
        }
        Debug.Log(Quaternion.Euler(开));

    }

    private void FixedUpdate()
    {
        if(状态==0)
        {
            transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(开), Time.deltaTime * 旋转速度);
        }else if(状态==1)
        {
            transform.rotation = Quaternion.Lerp(this.transform.rotation, 关, Time.deltaTime * 旋转速度);
        }


    }

}
