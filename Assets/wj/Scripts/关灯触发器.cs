using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 关灯触发器 : MonoBehaviour
{
    private FirstPersonController fpC;
    private Light torch;
    public 无锁门 无锁门;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        torch = other.gameObject.GetComponentInChildren<Light>();
        fpC = other.gameObject.GetComponent<FirstPersonController>();
        fpC.禁用手电 = true;
        torch.enabled = false;
        无锁门.开或关门();
        无锁门.上锁 = true;
        无锁门.开锁所需的道具ID = 21;

        gameObject.GetComponent<Collider>().enabled = false;
    }


}
