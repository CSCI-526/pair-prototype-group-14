using UnityEngine;

public class ResetPlayersPosition : MonoBehaviour
{
    
    public GameObject tile;  
    private TileTrigger tileTriggerScript; 


    private void Start()
    {
        if (tile != null)
        {
            tileTriggerScript = tile.GetComponent<TileTrigger>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleTilePosition();
        }
    }
    
    public void ToggleTilePosition()
    {
        if (tile != null)
        {
            tile.SetActive(true); 
            Debug.Log(tile.name + " activated by ResetPlayersPosition");
            
            if (tileTriggerScript != null)
            {
                tileTriggerScript.ResetPlayersOnTile();
            }
        }
    }
}