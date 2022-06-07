using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 电池 : MonoBehaviour
{
    public Text 旁白系统;

    private AudioSource 音频源;
    private FirstPersonController FPC;

    private void Awake()
    {
        音频源 = GetComponent<AudioSource>();
        FPC = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }



    public void 被交互()
    {
        音频源.Play();
        旁白系统.SendMessage("ShowDialog", "给手电筒换上了新电池");
        FPC.禁用手电 = false;


        Destroy(gameObject);
    }
}
