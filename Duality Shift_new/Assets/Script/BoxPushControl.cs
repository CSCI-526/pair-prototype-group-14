using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushControl : MonoBehaviour
{
    public float force = 10f; // Force to push the cube forward
    private int interactingPlayers = 0; // Counter to track interacting players
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    void OnCollisionEnter(Collision collision)
    {
        // Increase the counter when a "Player" tagged object collides with the cube
        if (collision.gameObject.CompareTag("Player"))
        {
            interactingPlayers++;
            CheckIfShouldMove();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Decrease the counter when a "Player" tagged object stops colliding with the cube
        if (collision.gameObject.CompareTag("Player"))
        {
            interactingPlayers--;
            CheckIfShouldMove();
        }
    }
    
    private void CheckIfShouldMove()
    {
        // If more than one player is interacting, make the cube non-kinematic and apply force
        if (interactingPlayers > 1)
        {
            rb.isKinematic = false; // Allow physics interactions
        }
        else
        {
            rb.isKinematic = true; // Disable movement when only one or no players are interacting
        }
    }

    void FixedUpdate()
    {
        if (interactingPlayers > 1)
        {
            rb.AddForce(Vector3.forward * force);
        }
    }
}
