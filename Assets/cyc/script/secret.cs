using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secret : MonoBehaviour
{
    public Text ����;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void NumberUp(Text ����)
    {
        ����.text = ((int.Parse(����.text) + 1) % 10).ToString();
    }
    public void NumberDown(Text ����)
    {
        ����.text = ((int.Parse(����.text) + 9) % 10).ToString();
    }
}
