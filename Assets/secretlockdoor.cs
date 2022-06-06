using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secretlockdoor : MonoBehaviour
{
    public GameObject 密码锁;
    public Text 密码1;
    public Text 密码2;
    public Text 密码3;
    public Text 密码4;
    public Text 密码;
    public bool 上锁 = false;
    public bool 显示密码锁 = false;

    public int 开锁所需的道具ID = 0;   //默认空手开门，即无锁

    private bool 已开 = false;
    private ItemManager 背包管理器;
    public Text 旁白系统;
    public float 旋转速度;
    public Transform open;
    public Transform close;
    Transform 目标;

    public void Start()
    {
        背包管理器 = GameObject.FindWithTag("Player").GetComponent<ItemManager>();
        目标 = close;
        Cursor.visible = 显示密码锁;
    }

    public void 被交互()
    {
        //密码锁要密码才能打开
        if (上锁)
        {
            显示锁();
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            开或关门();
        }

    }

    private void 开或关门()
    {
        if (已开)
        {
            目标 = close;
            已开 = !已开;
        }
        else
        {
            目标 = open;
            已开 = !已开;
        }
    }
    public void 检测密码()
    {
        密码.text= (int.Parse(密码1.text)*1000+ int.Parse(密码2.text) * 100+ int.Parse(密码3.text) * 10 + int.Parse(密码4.text)).ToString();
        if (密码.text =="3200")
        {
            上锁 = !上锁;
            显示锁();
            Cursor.lockState = CursorLockMode.Locked;
            旁白系统.SendMessage("ShowDialog", "密码正确");
            开或关门();
        }
        else
        {
            显示锁();
            Cursor.lockState = CursorLockMode.Locked;
            旁白系统.SendMessage("ShowDialog", "密码错误");
        }
    }
    public void 显示锁()
    {
        显示密码锁 = !显示密码锁;
        密码锁.SetActive(显示密码锁);
        Cursor.visible = 显示密码锁;
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, 目标.rotation, Time.deltaTime * 旋转速度);
    }
}
