using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject player1;    // the first character
    public GameObject player2;    // the second character
    public Camera mainCamera;     // main camera

    public Vector3 cameraOffset = new Vector3(0, 5, -10);  
    private GameObject activePlayer;  

    private bool isControllingBoth = false;  

    void Start()
    {
        
        activePlayer = player1;
        ActivatePlayer(player1, player2);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (activePlayer == player1)
            {
                ActivatePlayer(player2, player1);
            }
            else
            {
                ActivatePlayer(player1, player2);
            }
        }
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isControllingBoth = true;
            ControlBothPlayers(true);
        }
        else
        {
            isControllingBoth = false;
            ControlBothPlayers(false);
        }

        UpdateCameraPosition();
    }

    
    void ActivatePlayer(GameObject newActivePlayer, GameObject oldActivePlayer)
    {
        
        if (isControllingBoth) return;

        
        oldActivePlayer.GetComponent<PlayerController>().enabled = false;
        
        newActivePlayer.GetComponent<PlayerController>().enabled = true;

        
        activePlayer = newActivePlayer;
    }

    
    void ControlBothPlayers(bool controlBoth)
    {
        if (controlBoth)
        {
            
            player1.GetComponent<PlayerController>().enabled = true;
            player2.GetComponent<PlayerController>().enabled = true;
        }
        else
        {
            
            player1.GetComponent<PlayerController>().enabled = (activePlayer == player1);
            player2.GetComponent<PlayerController>().enabled = (activePlayer == player2);
        }
    }

    
    void UpdateCameraPosition()
    {
        if (activePlayer != null)
        {
            Vector3 desiredPosition = activePlayer.transform.position + cameraOffset;
            mainCamera.transform.position = desiredPosition;
            
            
        }
    }
}
