using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    public GameObject tile;             // Reference to the current tile's GameObject
    public GameObject nextTile;         // Reference to the next tile (e.g., Tile2)
    public GameObject nextTileTrigger;  // Reference to the trigger of the next tile (e.g., Tile2Trigger)
    private int playersOnTile = 0;      // Track how many players are on this tile

    // Called when a player enters this tile
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase the player count when a player steps on the tile
            playersOnTile++;

            // Activate both the next tile and its trigger
            if (nextTile != null)
            {
                nextTile.SetActive(true);
            }
            if (nextTileTrigger != null)
            {
                nextTileTrigger.SetActive(true);
            }
        }
    }

    // Called when a player exits this tile
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Decrease the player count when a player leaves the tile
            playersOnTile--;

            // Only deactivate the current tile and its trigger if no players are on it
            if (playersOnTile == 0)
            {
                if (tile != null)
                {
                    
                    tile.SetActive(false);
                    
                }
                if (nextTile == null) {
                    tile.SetActive(false);
                    nextTile.SetActive(false);// Deactivate the next tile's trigger
                    nextTileTrigger.SetActive(false); 
                }
                gameObject.SetActive(false);  // Deactivate the current trigger (this GameObject)
            }

            // Check if we can deactivate the next tile and its trigger
            if (nextTile != null)
            {
                TileTrigger nextTileScript = nextTile.GetComponent<TileTrigger>();
                
                // Only deactivate the next tile and trigger if no players are on it
                if (nextTileScript != null && nextTileScript.playersOnTile == 0)
                {
                    nextTile.SetActive(false);  // Deactivate the next tile
                    if (nextTileTrigger != null)
                    {
                        nextTileTrigger.SetActive(false); 
                        tile.SetActive(false);
                        nextTile.SetActive(false);// Deactivate the next tile's trigger
                    }
                }
            }
            
        }
    }
}




