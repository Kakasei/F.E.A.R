using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class 道具 :MonoBehaviour
{
    public int 道具ID;
    public ItemManager 道具管理器;
    public Text 旁白系统;
    public string 道具名;

    public void 拾取()
    {
        旁白系统.SendMessage("ShowDialog", "获得了" + 道具名);
        道具管理器.获得道具(道具ID);
        Destroy(gameObject);
    }

}
