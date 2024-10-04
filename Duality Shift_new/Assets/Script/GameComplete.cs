using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameComplete : MonoBehaviour
{
    public TextMeshProUGUI winText; // The End Text
    private int playersReached = 0;    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playersReached++;
            // If both of players reach the end
            if (playersReached == 2)
            {
                ShowWinText();
            }
        }
        
    }
    
    
    void ShowWinText()
    {
        winText.enabled = true; // Show the text
    }
}
