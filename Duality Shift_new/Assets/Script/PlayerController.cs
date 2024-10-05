using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;        
    public float jumpForce = 5f;    
    private Rigidbody rb;           
    private bool isGrounded = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }
    }
    
    void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Tile"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Tile"))
        {
            isGrounded = false;
        }
    }
}