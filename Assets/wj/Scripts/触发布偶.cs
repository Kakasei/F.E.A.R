using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 触发布偶 : MonoBehaviour
{

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
        }
    }
}
