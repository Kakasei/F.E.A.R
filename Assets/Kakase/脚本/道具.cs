using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class 道具 : MonoBehaviour
{
    [Header("交互型道具可以不管以下几项")]
    public int 道具ID;
    public ItemManager 道具管理器;
    public string 道具名;

    [Header("如果该道具不牵涉旁白，旁白系统不添加也行")]
    public Text 旁白系统;

    [Range(0, 1)] [Header("0是可拾取道具，1是可交互道具")] [SerializeField]
    private int 道具类型;

    public void 被交互()
    {
        switch (道具类型)
        {
            case 0:
                可拾取道具();
                拾取后触发();
                break;
            case 1:
                可交互道具();
                交互后触发();
                break;
        }
    }

    public void 可拾取道具()
    {
        旁白系统.SendMessage("ShowDialog", "获得了" + 道具名);
        道具管理器.获得道具(道具ID);
        //拾取到物品时，隐藏其模型和碰撞体，使其在游戏内呈现似乎已经被销毁的情况
        //延迟五秒再销毁该物品，因为有时候拾取物品需要触发一些 用协程实现的，延迟几秒才生效的代码
        //直接销毁会使得协程出错
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(延迟删除物体());
    }

    public virtual void 拾取后触发()
    {
        Debug.Log("拾取了" + 道具名);
    }



    public void 可交互道具()
    {

    }

    public virtual void 交互后触发()
    {
        Debug.Log("交互了" + 道具名);
    }

    private IEnumerator 延迟删除物体()
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log(this.name + "现在被彻底删除了");
        Destroy(this.gameObject);
    }
    
}
