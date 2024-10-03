using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRise : MonoBehaviour
{
    public Transform platform; // 指向需要升起的平台的引用
    public float riseHeight = 2.0f; // 平台升起的高度
    public float riseSpeed = 1.0f; // 平台升起的速度

    private bool triggered = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = platform.position; // 记录初始位置
    }

    void OnTriggerEnter(Collider other)
    {
        // 确认触发事件的是玩家或其他指定对象
        if (other.CompareTag("Player"))
        {
            if (!triggered)
            {
                triggered = true;
                StartCoroutine(RisePlatform());
            }
        }
    }

    IEnumerator RisePlatform()
    {
        // 等待3秒
        yield return new WaitForSeconds(3);
        
        // 在给定时间内平滑升高平台
        float elapsedTime = 0;
        while (elapsedTime < riseHeight / riseSpeed)
        {
            platform.position = Vector3.Lerp(startPosition, new Vector3(startPosition.x, startPosition.y + riseHeight, startPosition.z), (elapsedTime / (riseHeight / riseSpeed)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // 确保平台准确到达目标位置
        platform.position = new Vector3(startPosition.x, startPosition.y + riseHeight, startPosition.z);
    }
}
