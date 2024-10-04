using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    public GameObject tile;             // Reference to the current tile's GameObject
    public GameObject nextTile;         // Reference to the next tile (e.g., Tile2)
    public GameObject nextTileTrigger;  // Reference to the trigger of the next tile (e.g., Tile2Trigger)
    private int playersOnTile = 0;      // Track how many players are on this tile

    private void OnEnable()
    {
        playersOnTile = 0;
        Debug.Log(gameObject.name + " OnEnable: playersOnTile reset to 0");
    }

    // Called when a player enters this tile
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersOnTile++;
            Debug.Log("Player entered: " + gameObject.name + ", playersOnTile: " + playersOnTile);

            if (nextTile != null)
            {
                nextTile.SetActive(true);
                Debug.Log(nextTile.name + " activated");
            }
            if (nextTileTrigger != null)
            {
                nextTileTrigger.SetActive(true);
                Debug.Log(nextTileTrigger.name + " trigger activated");
            }
        }
    }

    // Called when a player exits this tile
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
