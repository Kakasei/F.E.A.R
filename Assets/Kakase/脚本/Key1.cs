using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{

    public int itemID = 2;

    private ItemManager IM;
    // Start is called before the first frame update
    private void Start()
    {
        IM = GameObject.FindWithTag("Player").GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void contact()
    {
        Debug.Log(123);
        IM.获得道具(itemID);
        //IM.addItem(itemID);
        Destroy(gameObject);
    }
}
