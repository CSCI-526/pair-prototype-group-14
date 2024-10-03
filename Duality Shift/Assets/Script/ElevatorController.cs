using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float speed = 2f;
    public float lowerHeight = 1f;
    public float upperHeight = 10f;

    private bool movingUp = true;          // 是否向上移动
    private bool isMoving = false;         // 是否正在移动

    public void ToggleMovement()
    {
        isMoving = !isMoving; // 切换移动状态
    }

    private void Update()
    {
        if (isMoving) // 如果平台处于移动状态
        {
            if (movingUp)
            {
                // 向上移动
                if (transform.position.y < upperHeight)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                }
                else
                {
                    movingUp = false; // 到达上限，改变方向
                }
            }
            else
            {
                // 向下移动
                if (transform.position.y > lowerHeight)
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
                else
                {
                    movingUp = true; // 到达下限，改变方向
                }
            }
        }
    }
}