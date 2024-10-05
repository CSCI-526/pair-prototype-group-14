using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float speed = 2f;
    public float lowerHeight = 1f;
    public float upperHeight = 10f;

    private bool movingUp = true;          
    private bool isMoving = false;         


    public void ToggleMovement()
    {
        isMoving = !isMoving; 
    }

    private void Update()
    {
        if (isMoving) 
        {
            if (movingUp)
            {
                if (transform.position.y < upperHeight)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                }
                else
                {
                    movingUp = false; 
                }
            }
            else
            {
                if (transform.position.y > lowerHeight)
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
                else
                {
                    movingUp = true; 
                }
            }
        }
    }
}