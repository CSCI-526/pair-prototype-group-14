using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public ElevatorController elevatorController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            elevatorController.ToggleMovement(); // 切换平台的移动状态
        }
    }
}