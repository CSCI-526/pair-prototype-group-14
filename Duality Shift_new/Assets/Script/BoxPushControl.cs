using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushControl : MonoBehaviour
{
    public float force = 10f; 
    private int playerCount = 0; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCount = playerCount + 1;
            Check();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCount = playerCount - 1; ;
            Check();
        }
    }
    
    private void Check()
    {
        
        if (playerCount > 1)
        {
            rb.isKinematic = false; 
        }
        else
        {
            rb.isKinematic = true; 
        }
    }

    void FixedUpdate()
    {
        if (playerCount > 1)
        {
            rb.AddForce(Vector3.forward * force);
        }
    }
}
