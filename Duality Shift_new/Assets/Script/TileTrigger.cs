using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    public GameObject tile;             // Reference to the current tile's GameObject
    public GameObject nextTile;         // Reference to the next tile (e.g., Tile2)
    public GameObject nextTileTrigger;  // Reference to the trigger of the next tile (e.g., Tile2Trigger)
    private int playersOnTile = 0;      // Track how many players are on this tile

<<<<<<< Updated upstream
=======
    private void OnEnable()
    {
        playersOnTile = 0;
        Debug.Log(gameObject.name + " OnEnable: playersOnTile reset to 0");
    }

>>>>>>> Stashed changes
    // Called when a player enters this tile
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            // Increase the player count when a player steps on the tile
            playersOnTile++;

            // Activate both the next tile and its trigger
            if (nextTile != null)
            {
                nextTile.SetActive(true);
=======
            playersOnTile++;
            Debug.Log("Player entered: " + gameObject.name + ", playersOnTile: " + playersOnTile);

            if (nextTile != null)
            {
                nextTile.SetActive(true);
                Debug.Log(nextTile.name + " activated");
>>>>>>> Stashed changes
            }
            if (nextTileTrigger != null)
            {
                nextTileTrigger.SetActive(true);
<<<<<<< Updated upstream
=======
                Debug.Log(nextTileTrigger.name + " trigger activated");
>>>>>>> Stashed changes
            }
        }
    }

    // Called when a player exits this tile
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
<<<<<<< Updated upstream
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




=======
            playersOnTile--;
            Debug.Log("Player exited: " + gameObject.name + ", playersOnTile: " + playersOnTile);

            if (playersOnTile <= 0)
            {
                if (tile != null)
                {
                    StartCoroutine(DeactivateAfterDelay(tile, 0.1f));
                }
                StartCoroutine(DeactivateAfterDelay(gameObject, 0.1f));
            }

            if (nextTile != null)
            {
                TileTrigger nextTileScript = nextTile.GetComponent<TileTrigger>();

                if (nextTileScript != null && nextTileScript.playersOnTile <= 0)
                {
                    StartCoroutine(DeactivateAfterDelay(nextTile, 0.1f));
                    if (nextTileTrigger != null)
                    {
                        StartCoroutine(DeactivateAfterDelay(nextTileTrigger, 0.1f));
                    }
                }
            }
        }
    }

    private IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        Debug.Log(obj.name + " deactivated after delay");
    }
    
    public void ResetPlayersOnTile()
    {
        playersOnTile = 0;
        Debug.Log(gameObject.name + " playersOnTile reset to 0 by ResetPlayersPosition");
    }
}
>>>>>>> Stashed changes
