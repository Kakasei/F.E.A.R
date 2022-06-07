using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Canvas UI;


    [SerializeField] private Image itemImage;

    public int 当前手持的道具ID = 0;     //默认为空手状态

    public List<int> 道具数量 = new List<int>(new int[100]);


    void Start()
    {
        itemImage = UI.GetComponentInChildren<Image>();
        道具数量[0] = 1;
        道具数量[1] = 1;
    }

    void Update()
    {
        鼠标滚轮切换道具();
    }

    private void 鼠标滚轮切换道具()
    {
        //鼠标向上滚动，值>0，反之同理
        float 滚轮倾向 = Input.GetAxis("Mouse ScrollWheel");

        if (滚轮倾向 > 0)
        {
            当前手持的道具ID++;
            当前手持的道具ID=ID合法化(当前手持的道具ID, 滚轮倾向);

            scrollItemUI(当前手持的道具ID);
        }
        else if (滚轮倾向 < 0)
        {
            当前手持的道具ID--;
            当前手持的道具ID=ID合法化(当前手持的道具ID, 滚轮倾向);

            scrollItemUI(当前手持的道具ID);
        }
    }

    private void scrollItemUI(int itemID)
    {
        itemImage.sprite = Resources.Load("IMG/" + itemID, typeof(Sprite)) as Sprite;
    }

    
    private int ID合法化(int ID,float 滚轮倾向)
    {
        if(滚轮倾向>0)
        {
            while (ID > 99||道具数量[ID]==0)   //检查是否上越界
            {
                ID++;
                if (ID > 99) ID = 0;   //ID上越界后置零
            }
        }else if(滚轮倾向<0)
        {
            while (ID < 0 || 道具数量[ID] == 0)    //检查是否下越界
            {
                ID--;
                if (ID <0) ID = 99;   //ID下越界后置满
            }
        }
        return ID;
    }

    public bool 消耗道具(int 道具ID)
    {
        if(道具数量[道具ID]>=1)
        {
            道具数量[道具ID] -=1;
            if (道具数量[道具ID] == 0)
            {
                道具ID = ID合法化(道具ID + 1, 1); //如果恰好当前道具被消耗光了，UI就显示下一个道具
                scrollItemUI(道具ID);
            }
            return true;
        }else
        {
            return false;
        }
    }
    
    public void 获得道具(int ID)
    {
        道具数量[ID]++;
    }

}
