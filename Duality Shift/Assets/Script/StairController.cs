using UnityEngine;

public class StairController : MonoBehaviour
{
    public float speed = 2f; // 楼梯移动速度
    private Vector3 targetPosition; // 楼梯的目标位置
    private Vector3 originalPosition; // 楼梯的原始位置
    private bool moveToTarget = false; // 控制楼梯是否移动到目标位置

    void Start()
    {
        originalPosition = new Vector3(135, transform.position.y, transform.position.z); // 设置原始位置
        targetPosition = new Vector3(126, transform.position.y, transform.position.z); // 设置目标位置
        transform.position = originalPosition; // 确保楼梯从原始位置开始
    }

    public void ToggleStairPosition()
    {
        moveToTarget = !moveToTarget; // 切换楼梯的移动状态
    }

    void Update()
    {
        if (moveToTarget)
        {
            // 移动楼梯到目标位置
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            // 移动楼梯回到原始位置
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
        }
    }
}