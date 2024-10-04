using UnityEngine;

public class StairTrigger : MonoBehaviour
{
    public StairController stairController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stairController.ToggleStairPosition(); 
        }
    }
}