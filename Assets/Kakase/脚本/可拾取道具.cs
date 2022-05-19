using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 可拾取道具 : MonoBehaviour
{
    public int itemID;
    public ItemManager IM;
    public Text dialogSystem;
    public string itemName;

    public void 被交互()
    {

    }

    public void contact()
    {
        dialogSystem.SendMessage("ShowDialog", "获得了" + itemName);
        IM.获得道具(itemID);
        //IM.addItem(itemID);
        Destroy(gameObject);
    }
}
