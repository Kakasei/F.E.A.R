using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactDialog : MonoBehaviour
{
    public Text dialogSystem;
    public string dialog;

    public void contact()
    {
        dialogSystem.SendMessage("ShowDialog", dialog);
    }
}
