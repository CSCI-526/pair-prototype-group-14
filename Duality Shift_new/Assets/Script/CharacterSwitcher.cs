using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject player1;    // the first character
    public GameObject player2;    // the second character
    public Camera mainCamera;     // main camera

    public Vector3 cameraOffset = new Vector3(0, 5, -10);  // camera offset
    private GameObject activePlayer;  // Currently Controlled Role

    private bool isControllingBoth = false;  // Marks whether two roles are controlled at the same time

    void Start()
    {
        // Initialization sets player1 as the active character
        activePlayer = player1;
        ActivatePlayer(player1, player2);
    }

    void Update()
    {
        // Press the “R” key to switch characters
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

        // Detecting the “Shift” key, if pressed, controls the movement of both characters together.
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

    // Switching control roles and disabling control of old roles
    void ActivatePlayer(GameObject newActivePlayer, GameObject oldActivePlayer)
    {
        // If you are currently in simultaneous control, do not switch roles
        if (isControllingBoth) return;

        // Disable the old role controller to make sure it can't control the
        oldActivePlayer.GetComponent<PlayerController>().enabled = false;
        // Enabling new role controllers
        newActivePlayer.GetComponent<PlayerController>().enabled = true;

        // Update references to currently active roles
        activePlayer = newActivePlayer;
    }

    // Logic for controlling two roles
    void ControlBothPlayers(bool controlBoth)
    {
        if (controlBoth)
        {
            // Enable controllers for both roles to control both roles
            player1.GetComponent<PlayerController>().enabled = true;
            player2.GetComponent<PlayerController>().enabled = true;
        }
        else
        {
            // Enable only the controller with the currently active role
            player1.GetComponent<PlayerController>().enabled = (activePlayer == player1);
            player2.GetComponent<PlayerController>().enabled = (activePlayer == player2);
        }
    }

    // Update the camera position to follow the currently active character
    void UpdateCameraPosition()
    {
        if (activePlayer != null)
        {
            Vector3 desiredPosition = activePlayer.transform.position + cameraOffset;
            mainCamera.transform.position = desiredPosition;
            //mainCamera.transform.rotation = Quaternion.Euler(100, 300, 0);
            //mainCamera.transform.LookAt(activePlayer.transform);
        }
    }
}
