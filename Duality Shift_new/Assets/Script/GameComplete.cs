using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameComplete : MonoBehaviour
{
    public TextMeshProUGUI winText; 
    private int reached = 0;    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            reached++;
            
            if (reached == 2)
            {
                winText.enabled = true;
            }
        }
        
    }
    
    
}
