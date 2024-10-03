using UnityEngine;

public class StairTrigger : MonoBehaviour
{
    public StairController stairController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stairController.ToggleStairPosition(); // 切换楼梯的位置状态
        }
    }
}