using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 猫眼 : 道具
{
    public RawImage 猫眼鬼图;

    public BoxCollider 碰撞体;

    private void Start()
    {
        碰撞体 = this.gameObject.GetComponent<BoxCollider>();
        
    }

    public override void 交互后触发()
    {
        猫眼鬼图.enabled = true;
        碰撞体.enabled = false;
        StartCoroutine(鬼图播放完后删除());

    }

    private IEnumerator 鬼图播放完后删除()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log(this.name + "现在被彻底删除了");
        Destroy(this.gameObject);
    }
}
