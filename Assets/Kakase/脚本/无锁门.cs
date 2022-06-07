using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class 无锁门 : MonoBehaviour
{
    public bool 上锁 = false;
    public bool 锁死 = false;

    public int 开锁所需的道具ID = 0;   //默认空手开门，即无锁

    private bool 已开 = false;
    private ItemManager 背包管理器;
    public Text 旁白系统;
    public float 旋转速度;
    public Transform open;
    public Transform close;
    Transform 目标;

    [Header("这里填开门所用的道具名称")][SerializeField]
    private string 所需的道具的名称;

    public AudioClip 开门音效, 关门音效;

    private AudioSource 音频源;

    private void Awake()
    {
        音频源 = GetComponent<AudioSource>();
    }

    public void Start()
    {
        背包管理器 = GameObject.FindWithTag("Player").GetComponent<ItemManager>();
        目标 = close;
    }

    public void 被交互()
    {
        Debug.Log(this.name+"被交互");

        //被锁死的门无论如何都无法打开
        if (锁死==false)
        {
            //上锁的门需要对应钥匙才能打开
            if (上锁)
            {
                if (背包管理器.消耗道具(开锁所需的道具ID))  //如果成功消耗了所需的开门道具
                {
                    上锁 = !上锁;
                    旁白系统.SendMessage("ShowDialog", "用"+所需的道具的名称+"打开了门");
                    开或关门();
                }
                else
                {
                    旁白系统.SendMessage("ShowDialog", "没有对应的钥匙");
                }
            }
            else
            {
                开或关门();
            }
        }else if(锁死==true)
        {
            旁白系统.SendMessage("ShowDialog", "打不开");
            旁白系统.SendMessage("ShowDialog", "怎么办，从猫眼看看什么情况吧");
        }
        

    }

    private void 开或关门()
    {
    //    音频源.Play();
        if (已开)
        {
            音频源.clip = 关门音效;
            音频源.Play();
            目标 = close;
            已开 = !已开;
        }
        else
        {
            音频源.clip = 开门音效;
            音频源.Play();
            目标 = open;
            已开 = !已开;
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,目标.rotation,Time.deltaTime * 旋转速度);
    }
}
