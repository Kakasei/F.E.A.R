using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class 道具 : MonoBehaviour
{
    [Tooltip("可交互道具无需填写ID")]
    public int 道具ID;

    public ItemManager 道具管理器;
    public Text 旁白系统;
    public string 道具名;

    [Range(0, 1)] [Tooltip("0是可拾取道具，1是可交互道具")] [SerializeField]
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
                break;
        }
    }


    public void 可拾取道具()
    {
        Debug.Log("test");
        旁白系统.SendMessage("ShowDialog", "获得了" + 道具名);
        道具管理器.获得道具(道具ID);
        Destroy(gameObject);
    }

    public virtual void 拾取后触发()
    {
        Debug.Log("拾取了" + 道具名);
    }


    public void 可交互道具()
    {

    }
}
