using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secret : MonoBehaviour
{
    public Text ����;
    private void Start()
    {
        
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
