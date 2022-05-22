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


    public void 触发血手印()
    {
        StartCoroutine(血脚印出现());
    }

    private IEnumerator 血手印出现()
    {
        for(int i = 1; i <= 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log(血手印集[i].name);
            血手印集[i].gameObject.SetActive(true);
            音频源.Play();
        }
    }

    private IEnumerator 血脚印出现()
    {
        yield return StartCoroutine(血手印出现());

        for (int i = 4; i <= 7; i++)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log(血手印集[i].name);
            血手印集[i].gameObject.SetActive(true);
            音频源.Play();
        }
    }
}
