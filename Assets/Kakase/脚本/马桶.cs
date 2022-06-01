using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 马桶 : 道具
{

    private Vector3 开;
    private Vector3 关;
    private Vector3 目标;

    public float 旋转速度;
    [Header("旋转角度")]
    public int x;
    public int y;
    public int z;

    private void Start()
    {
        关 = this.transform.rotation.eulerAngles;
        开 = new Vector3(x, y, z);

        目标 = 关;
    }

    public override void 交互后触发()
    {
        Debug.Log("交互了");
        if(目标==开)
        {
            目标 = 关;
        }else if(目标==关)
        {
            目标 = 开;
        }
    }


    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(目标), Time.deltaTime * 旋转速度);
    }


}
