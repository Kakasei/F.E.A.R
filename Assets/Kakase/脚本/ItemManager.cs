using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Canvas UI;



    [SerializeField] private Image itemImage;

    //private int ����ID = 0;     //0�ǿ���,2��key01��
    //private int itemCount = 2;
    //public List<bool> hasItem = new List<bool>(new bool[100]);

    public int ��ǰ�ֳֵĵ���ID = 0;     //Ĭ��Ϊ����״̬
    private int ���е������� = 2;
    public List<int> �������� = new List<int>(new int[100]);


    void Start()
    {
        //hasItem[0] = true;
        //hasItem[1] = true;
        itemImage = UI.GetComponentInChildren<Image>();
        ��������[0] = 1;
        ��������[1] = 1;
    }

    void Update()
    {
        �������л�����();
    }

    private void �������л�����()
    {
        //������Ϲ�����ֵ>0����֮ͬ��
        float �������� = Input.GetAxis("Mouse ScrollWheel");

        if (�������� > 0)
        {
            ��ǰ�ֳֵĵ���ID++;
            ��ǰ�ֳֵĵ���ID=ID�Ϸ���(��ǰ�ֳֵĵ���ID, ��������);

            scrollItemUI(��ǰ�ֳֵĵ���ID);
        }
        else if (�������� < 0)
        {
            ��ǰ�ֳֵĵ���ID--;
            ��ǰ�ֳֵĵ���ID=ID�Ϸ���(��ǰ�ֳֵĵ���ID, ��������);

            scrollItemUI(��ǰ�ֳֵĵ���ID);
        }
    }

    private void scrollItemUI(int itemID)
    {
        itemImage.sprite = Resources.Load("IMG/" + itemID, typeof(Sprite)) as Sprite;
    }

    
    private int ID�Ϸ���(int ID,float ��������)
    {
        if(��������>0)
        {
            while (ID > 99||��������[ID]==0)   //����Ƿ���Խ��
            {
                ID++;
                if (ID > 99) ID = 0;   //ID��Խ�������
            }
        }else if(��������<0)
        {
            while (ID < 0 || ��������[ID] == 0)    //����Ƿ���Խ��
            {
                ID--;
                if (ID <0) ID = 99;   //ID��Խ�������
            }
        }
        return ID;
    }

    /*

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
    }*/
    /*
    public void addItem(int ����ID)
    {
        hasItem[����ID] = true;
        itemCount++;
    }
    *//*
    public bool useItem(int ����ID)
    {
        if(hasItem[����ID])
        {
            hasItem[����ID] = false;
            ����ID++;
            ����ID = ClampItem1(����ID);
            scrollItemUI(����ID);
            return true;
        }else
        {
            return false;
        }
    }
    */
    public bool ���ĵ���(int ����ID)
    {
        if(��������[����ID]>=1)
        {
            ��������[����ID] -=1;
            if (��������[����ID] == 0)
            {
                ����ID = ID�Ϸ���(����ID + 1, 1); //���ǡ�õ�ǰ���߱����Ĺ��ˣ�UI����ʾ��һ������
                scrollItemUI(����ID);
            }
            return true;
        }else
        {
            return false;
        }
    }
    
    public void ��õ���(int ID)
    {
        if (��������[ID] == 0) ���е�������++;
        ��������[ID]++;
    }
}
