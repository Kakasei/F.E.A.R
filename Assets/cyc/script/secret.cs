using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secret : MonoBehaviour
{
    public Text 数字;
    private void Start()
    {
        
    }
    public void NumberUp(Text 数字)
    {
        数字.text = ((int.Parse(数字.text) + 1) % 10).ToString();
    }
    public void NumberDown(Text 数字)
    {
        数字.text = ((int.Parse(数字.text) + 9) % 10).ToString();
    }
}
