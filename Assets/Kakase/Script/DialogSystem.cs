using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public float fadeTime;
    public float showTime;
    public float continueTime;

    private Text text;
    private float fadeSpeed;
    private float showSpeed;
    private float instantiateTime;
    public bool showing = false;
    public bool spanning = false;
    public bool disappearing = true;
    private Queue<string> dialogs = new Queue<string>();
    void Start()
    {
        text = GetComponent<Text>();
        fadeSpeed = 1 / fadeTime;
        showSpeed = 1 / showTime;
        instantiateTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (spanning && dialogs.Count > 0)
        {
            spanning = false;
            text.text = dialogs.Dequeue();
            showing = true;
            instantiateTime = Time.time;
        }
        if (showing)
        {
            text.color = new Color(0, 0, 0, showSpeed * 0.02f) + text.color;
            if (text.color.a >= 1f)
            {
                showing = false;
                disappearing = true;
            }
                
        }

        if (disappearing)
        {
            text.color = new Color(0, 0, 0, -fadeSpeed * Time.deltaTime) + text.color;
            if (text.color.a <= 0)
            {
                disappearing = false;
                spanning = true;
            }
        }
    }
    void Update()
    {
        
    }

    void ChangeContinueTime(float time)
    {
        continueTime = time;
    }

    void ShowDialog(string s)
    {
        dialogs.Enqueue(s);
    }
}
