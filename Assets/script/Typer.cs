using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Typer : MonoBehaviour
{
    int i = 0;
    Text text1;
    public string[] msgs;
    // Start is called before the first frame update
    void Start()
    {
        text1 = GetComponent<Text>();
        TypeContect(text1.text);
    }

    public void TypeContect(String contect)
    {
        StartCoroutine(routine: StartType(contect));
    }

    IEnumerator StartType(String content)
    {
        var wait = new WaitForSeconds(.05f);
        for (int i = 0; i <= content.Length; i++)
        {
            text1.text = content.Substring(startIndex: 0, length: i);
            yield return wait;
        }
    }

    public void ChangeContect()
    {
        text1.text = msgs[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (i < msgs.Length)
            {
                ChangeContect();
                TypeContect(text1.text);
                i++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}