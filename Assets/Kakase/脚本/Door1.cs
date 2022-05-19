using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    private ItemManager IM;
    private Animator ani;


    // Start is called before the first frame update
    void Start()
    {
        IM = GameObject.FindWithTag("Player").GetComponent<ItemManager>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void contact()
    {
        Debug.Log("contact!");
        if(IM.ÏûºÄµÀ¾ß(2))
        {
            ani.SetTrigger("Open");
        }
    }

}
