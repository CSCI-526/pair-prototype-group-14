using UnityEngine;

public class StairController : MonoBehaviour
{
    public float speed = 2f; 
    private Vector3 targetPosition; 
    private Vector3 originalPosition; 
    private bool moveToTarget = false; 


    void Start()
    {
        originalPosition = new Vector3(135, transform.position.y, transform.position.z); 
        targetPosition = new Vector3(125, transform.position.y, transform.position.z); 
        transform.position = originalPosition; 
    }

    public void ToggleStairPosition()
    {
        moveToTarget = !moveToTarget; 
    }

    void Update()
    {
        if (moveToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
        }
    }
}