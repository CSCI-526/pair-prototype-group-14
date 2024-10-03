using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatformController : MonoBehaviour
{
    public float speed = 2f;               // 平台移动的速度
    public float lowerHeight = 0f;         // 平台的最低位置
    public float upperHeight = 10f;        // 平台的最高位置

    private bool movingUp = true;          // 平台是否在上升

    void Update()
    {
        // 平台上升
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            // 如果平台到达了最高位置，则改变方向
            if (transform.position.y >= upperHeight)
            {
                movingUp = false;
            }
        }
        // 平台下降
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // 如果平台到达了最低位置，则改变方向
            if (transform.position.y <= lowerHeight)
            {
                movingUp = true;
            }
        }
    }
}