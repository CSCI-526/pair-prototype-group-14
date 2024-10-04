using UnityEngine;

public class ResetPlayersPosition : MonoBehaviour
{
    // TileTrigger script object
    public GameObject tile;  // Tile object to activate
    private TileTrigger tileTriggerScript; // Corresponding TileTrigger script


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