using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTriggerController : MonoBehaviour
{
    public GameObject platform;        
    public float speed = 2f;           
    public float lowerHeight = 0f;     
    public float upperHeight = 10f;    

    private bool playerOnPlatform = false; 
    private bool movingUp = true;          

    private void Update()
    {
        if (playerOnPlatform)
        {
            MovePlatform();
        }
    }
    
    public void MovePlatform()
    {
        if (movingUp)
        {
            platform.transform.Translate(Vector3.up * speed * Time.deltaTime);
            
            if (platform.transform.position.y >= upperHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            platform.transform.Translate(Vector3.down * speed * Time.deltaTime);
            
            if (platform.transform.position.y <= lowerHeight)
            {
                movingUp = true;
            }
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;  
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false; 
        }
    }
}