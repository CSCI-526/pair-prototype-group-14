using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject character1;    // First character
    public GameObject character2;    // Second character
    public Camera mainCamera;        // Main camera

    public Vector3 cameraOffset = new Vector3(0, 5, -10);  // Offset of the camera from the character
    private GameObject activeCharacter;  // Reference to the current active character
    private bool isControllingBoth = false; // Flag to check if both characters are being controlled

    void Start()
    {
        // Set the initial active character
        activeCharacter = character1;
        SwitchCharacter(character1, character2);
    }

    void Update()
    {
        // Detect key press to switch characters
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (activeCharacter == character1)
            {
                SwitchCharacter(character2, character1);
            }
            else
            {
                SwitchCharacter(character1, character2);
            }
        }

        // Detect holding the "P" key to control both characters
        if (Input.GetKey(KeyCode.P))
        {
            ControlBothCharacters(true);
        }
        else
        {
            ControlBothCharacters(false);
        }
        UpdateCameraPosition();

    }

    // Method to switch the character and camera
    void SwitchCharacter(GameObject newActiveCharacter, GameObject oldActiveCharacter)
    {
        // If controlling both, skip character switching
        if (isControllingBoth) return;

        // Disable old character controls and enable the new one
        oldActiveCharacter.GetComponent<PlayerController>().enabled = false;
        newActiveCharacter.GetComponent<PlayerController>().enabled = true;

        // Switch the active character reference
        activeCharacter = newActiveCharacter;

        // Update camera position to follow the new active character (assuming you're not using Cinemachine)
        mainCamera.transform.position = newActiveCharacter.transform.position + new Vector3(0, 5, -10);
        mainCamera.transform.LookAt(newActiveCharacter.transform);
    }

    // Method to control both characters
    void ControlBothCharacters(bool controlBoth)
    {
        isControllingBoth = controlBoth;

        if (controlBoth)
        {
            // Enable both character controllers
            character1.GetComponent<PlayerController>().enabled = true;
            character2.GetComponent<PlayerController>().enabled = true;
        }
        else
        {
            // Only enable the currently active character
            character1.GetComponent<PlayerController>().enabled = (activeCharacter == character1);
            character2.GetComponent<PlayerController>().enabled = (activeCharacter == character2);
        }
    }
    void UpdateCameraPosition()
    {
        if (activeCharacter != null)
        {
            // Desired camera position based on the active character's position + offset
            Vector3 desiredPosition = activeCharacter.transform.position + cameraOffset;


            // Update the camera position
            mainCamera.transform.position = desiredPosition;

            // Make the camera always look at the active character
            mainCamera.transform.LookAt(activeCharacter.transform);
        }
    }
}
