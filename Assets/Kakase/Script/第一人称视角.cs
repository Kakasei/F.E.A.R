using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 第一人称视角 : MonoBehaviour
{
    //--------视角相关---------
    public float 仰角限制 = 75f;
    public float 俯角限制 = -75f;

    public float x轴灵敏度 = 3f;
    public float y轴灵敏度 = 1f;

    private float y轴旋转 = 0f;
    private float x轴旋转;
    //--------视角相关---------


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        视角旋转();
        Debug.Log(transform.parent);
    }

    private void 视角旋转()
    {
        float 鼠标x轴输入 = Input.GetAxisRaw("Mouse X");
        float 鼠标y轴输入 = Input.GetAxisRaw("Mouse Y");
        y轴旋转 -= 鼠标y轴输入 * y轴灵敏度;
        y轴旋转 = Mathf.Clamp(y轴旋转, 俯角限制, 仰角限制);
        transform.localEulerAngles = new Vector3(y轴旋转, 0, 0);
        transform.parent.Rotate(new Vector3(0,1,0)*鼠标x轴输入);

        /*float x轴旋转 = transform.localEulerAngles.y + Input.GetAxisRaw("Mouse X") * x轴灵敏度;
        y轴旋转 += Input.GetAxisRaw("Mouse Y") * y轴灵敏度;
        y轴旋转 = Mathf.Clamp(y轴旋转, 俯角限制, 仰角限制);
        transform.localEulerAngles = new Vector3(-y轴旋转, x轴旋转, 0);
        transform.localEulerAngles = new Vector3(-y轴旋转, x轴旋转, 0);*/

    }
}
