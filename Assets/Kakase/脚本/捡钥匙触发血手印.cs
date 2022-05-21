using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 捡钥匙触发血手印 : MonoBehaviour
{
    private Transform[] 血手印集;
    private AudioSource 音频源;

    private void Awake()
    {
        血手印集 = GetComponentsInChildren<Transform>(true);
        音频源 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 触发血手印()
    {
        Debug.Log(血手印集[1].name);
        血手印集[1].gameObject.SetActive(true);
        音频源.Play();
    }
}
