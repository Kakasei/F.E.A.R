using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public int itemID;
    public ItemManager IM;
    public Text dialogSystem;
    public string itemName;


    public void contact()
    {
        dialogSystem.SendMessage("ShowDialog", "�����"+itemName);
        IM.��õ���(itemID);
        //IM.addItem(itemID);
        Destroy(gameObject);
    }
}
