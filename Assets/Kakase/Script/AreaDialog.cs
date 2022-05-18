using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaDialog : MonoBehaviour
{
    public Text dialogSystem;
    public string dialog;//wj

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            Debug.Log(12345);
            dialogSystem.SendMessage("ShowDialog", dialog);
            Destroy(gameObject);
        }
    }
}
