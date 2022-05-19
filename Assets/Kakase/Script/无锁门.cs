using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 无锁门 : MonoBehaviour
{
    private Animator 动画器;
    private bool 是否为开 = false;

    public void Start()
    {
        动画器 = GetComponent<Animator>();
    }

    public void 被交互()
    {
        Debug.Log(123);
        if(是否为开)
        {
            动画器.SetTrigger("关");
            是否为开 = !是否为开;
        }
        else
        {
            动画器.SetTrigger("开");
            是否为开 = !是否为开;
        }
    }

}
