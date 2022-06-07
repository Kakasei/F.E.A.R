using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 触发布偶 : MonoBehaviour
{

    public Rigidbody rb;
    AudioSource fallenAudio;
    private int count;

    private void Start()
    {
        fallenAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 1;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && count > 0)
        {
            fallenAudio.Play();
            rb.isKinematic = false;
            count--;
        }
    }
}
