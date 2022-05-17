using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Canvas UI;



    [SerializeField] private Image itemImage;
    private int itemID = 0;     //0 «ø’ ÷,2 «key01£¨
    private int itemCount = 2;
    private List<bool> hasItem = new List<bool>(new bool[100]);
    


    void Start()
    {
        hasItem[0] = true;
        hasItem[1] = true;
        itemImage = UI.GetComponentInChildren<Image>();
    }

    void Update()
    {
        switchItem();
    }

    private void switchItem()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0)
        {
            itemID++;
            itemID = ClampItem1(itemID);
            scrollItemUI(itemID);
        }
        else if (scroll < 0)
        {
            itemID--;
            itemID = ClampItem0(itemID);
            scrollItemUI(itemID);
        }
    }

    private void scrollItemUI(int itemID)
    {
        itemImage.sprite = Resources.Load("IMG/" + itemID, typeof(Sprite)) as Sprite;
    }


    private int ClampItem1(int n)
    {
        while ( n == itemCount ||!hasItem[n])
        {
            n++;
            if (n >= itemCount) n = 0;
        }
        return n;
    }
    private int ClampItem0(int n)
    {
        while (n < 0 || !hasItem[n])
        {
            n--;
            if (n < 0) n = itemCount - 1;
        }
        return n;
    }

    public void addItem(int itemID)
    {
        hasItem[itemID] = true;
        itemCount++;
    }

    public bool useItem(int itemID)
    {
        if(hasItem[itemID])
        {
            hasItem[itemID] = false;
            itemID++;
            itemID = ClampItem1(itemID);
            scrollItemUI(itemID);
            return true;
        }else
        {
            return false;
        }
    }
    
}
