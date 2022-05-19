using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 无锁门 : MonoBehaviour
{
    public bool 上锁 = false;
    public int 开锁所需的道具ID = 0;   //默认空手开门，即无锁

    private Animator 动画器;
    private bool 已开 = false;
    private ItemManager 背包管理器;
    public Text 旁白系统;

    public void Start()
    {
        动画器 = GetComponent<Animator>();
        背包管理器 = GameObject.FindWithTag("Player").GetComponent<ItemManager>();
    }

    public void 被交互()
    {
        Debug.Log(this.name+"被交互");

        //上锁的门需要对应钥匙才能打开
        if (上锁)
        {
            if (背包管理器.消耗道具(开锁所需的道具ID))  //如果成功消耗了所需的开门道具
            {
                上锁 = !上锁;
                旁白系统.SendMessage("ShowDialog", "用钥匙打开了门");
                开或关门();
            }else
            {
                旁白系统.SendMessage("ShowDialog", "没有对应的钥匙");
            }
        }else
        {
            开或关门();
        }

    }

    private void 开或关门()
    {
        if (已开)
        {
            动画器.SetTrigger("关");
            已开 = !已开;
        }
        else
        {
            动画器.SetTrigger("开");
            已开 = !已开;
        }
    }

}
