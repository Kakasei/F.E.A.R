using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class 厕所门 : MonoBehaviour
{
    public bool 锁死 = false;

    private bool 已开 = false;

    public Text 旁白系统;
    public float 旋转速度;
    public Transform open;
    public Transform close;
    Transform 目标;


    public AudioClip 开门音效, 关门音效;

    private AudioSource 音频源;

    private void Awake()
    {
        音频源 = GetComponent<AudioSource>();
    }

    public void Start()
    {

        目标 = close;
    }

    public void 被交互()
    {
        Debug.Log(this.name + "被交互");

        //被锁死的门无论如何都无法打开
        if (锁死 == false)
        {
            开或关门();
            
        }
        else if (锁死 == true)
        {
            旁白系统.SendMessage("ShowDialog", "打不开,从猫眼看看什么情况吧");
        }


    }

    private void 开或关门()
    {
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
        transform.rotation = Quaternion.Lerp(transform.rotation, 目标.rotation, Time.deltaTime * 旋转速度);
    }
}
