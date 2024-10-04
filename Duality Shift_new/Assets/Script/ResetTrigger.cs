using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    public ResetPlayersPosition stairController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stairController.ToggleTilePosition(); 
        }
    }
}