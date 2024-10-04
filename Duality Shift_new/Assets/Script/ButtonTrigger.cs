using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public ElevatorController elevatorController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            elevatorController.ToggleMovement(); 
        }
    }
}