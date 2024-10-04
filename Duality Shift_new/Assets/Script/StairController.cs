using UnityEngine;

public class StairController : MonoBehaviour
{
    public float speed = 2f; // Speed of the stairs' movement
    private Vector3 targetPosition; // Target position of the stairs
    private Vector3 originalPosition; // Original position of the stairs
    private bool moveToTarget = false; // Controls whether the stairs move to the target position


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