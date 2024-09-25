using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;        // Speed of movement
    public float jumpForce = 5f;    // Jump force
    private Rigidbody rb;           // Rigidbody reference
    private bool isGrounded = true; // Check if the player is on the ground

    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the player (WASD or Arrow keys)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Jump when space is pressed and player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Player is in the air now
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Allow jumping again when touching the ground
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}


