using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 马桶里的道具 : 道具
{
    public 无锁门 厕所门脚本;
    private void Start()
    {
        
    }



    public override void 拾取后触发()
    {
        base.拾取后触发();
        厕所门脚本.旋转速度 = 5.0f;
        厕所门脚本.被交互();
        厕所门脚本.锁死 = true;
        StartCoroutine(锁门());
    }
    
    public IEnumerator 锁门()
    {
        yield return new WaitForSeconds(2.0f);
        //厕所门脚本.enabled = false;
    }
}
