using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secretlockdoor : MonoBehaviour
{
    public GameObject ������;
    public bool ���� = false;
    public bool ���� = false;
    public bool ��ʾ������ = false;

    public int ��������ĵ���ID = 0;   //Ĭ�Ͽ��ֿ��ţ�������

    private bool �ѿ� = false;
    private ItemManager ����������;
    public Text �԰�ϵͳ;
    public float ��ת�ٶ�;
    public Transform open;
    public Transform close;
    Transform Ŀ��;

    public void Start()
    {
        ���������� = GameObject.FindWithTag("Player").GetComponent<ItemManager>();
        Ŀ�� = close;
        Cursor.visible = ��ʾ������;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ������()
    {
        Debug.Log(this.name + "������");

        //����������������ζ��޷���
        if (���� == false)
        {
            ��ʾ��();
            //����������Ҫ��ӦԿ�ײ��ܴ�
            if (����)
            {
                if (����������.���ĵ���(��������ĵ���ID))  //����ɹ�����������Ŀ��ŵ���
                {
                    ���� = !����;
                    �԰�ϵͳ.SendMessage("ShowDialog", "��Կ�״�����");
                    �������();
                }
                else
                {
                    �԰�ϵͳ.SendMessage("ShowDialog", "û�ж�Ӧ��Կ��");
                }
            }
            else
            {
                �������();
            }
        }
        else if (���� == true)
        {
            �԰�ϵͳ.SendMessage("ShowDialog", "�򲻿�");
            �԰�ϵͳ.SendMessage("ShowDialog", "��ô�죬��è�ۿ���ʲô�����");
        }


    }

    private void �������()
    {
        if (�ѿ�)
        {
            Ŀ�� = close;
            �ѿ� = !�ѿ�;
        }
        else
        {
            Ŀ�� = open;
            �ѿ� = !�ѿ�;
        }
    }

    public void ��ʾ��()
    {
        ��ʾ������ = !��ʾ������;
        ������.SetActive(��ʾ������);
        Cursor.visible = ��ʾ������;
        Cursor.lockState = CursorLockMode.None;
    }
    private void FixedUpdate()
    {
        if (true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Ŀ��.rotation, Time.deltaTime * ��ת�ٶ�);
        }
    }
}
