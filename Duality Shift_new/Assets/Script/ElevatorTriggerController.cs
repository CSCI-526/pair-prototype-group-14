using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTriggerController : MonoBehaviour
{
    public GameObject platform;        // 平台对象
    public float speed = 2f;           // 平台移动速度
    public float lowerHeight = 0f;     // 平台的最低位置
    public float upperHeight = 10f;    // 平台的最高位置

    private bool playerOnPlatform = false; // 标记玩家是否在平台上
    private bool movingUp = true;          // 平台是否在上升

    void Update()
    {
        // 如果玩家站在平台上，则移动平台
        if (playerOnPlatform)
        {
            MovePlatform();
        }
    }

    // 平台的升降逻辑
    void MovePlatform()
    {
        if (movingUp)
        {
            platform.transform.Translate(Vector3.up * speed * Time.deltaTime);

            // 如果平台到达最高位置，则改变方向
            if (platform.transform.position.y >= upperHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            platform.transform.Translate(Vector3.down * speed * Time.deltaTime);

            // 如果平台到达最低位置，则改变方向
            if (platform.transform.position.y <= lowerHeight)
            {
                movingUp = true;
            }
        }
    }

    // 当玩家进入触发器时
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;  // 标记玩家已站在平台上
        }
    }

    // 当玩家离开触发器时
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;  // 标记玩家已离开平台
        }
    }
}