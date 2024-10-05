using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatformController : MonoBehaviour
{
    public float speed = 2f;               
    public float lowerHeight = 0f;         
    public float upperHeight = 10f;        


    private bool movingUp = true;          

    private void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            
            if (transform.position.y >= upperHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            
            if (transform.position.y <= lowerHeight)
            {
                movingUp = true;
            }
        }
    }
}