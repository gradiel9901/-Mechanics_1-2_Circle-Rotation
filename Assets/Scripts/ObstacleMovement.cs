using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Speed of the obstacle
    [SerializeField] private float leftBoundary = -8f; // Left boundary of the screen (adjust based on your scene)
    [SerializeField] private float rightBoundary = 8f; // Right boundary of the screen (adjust based on your scene)

    private bool movingRight = true; // Track whether the obstacle is moving right

    void Update()
    {
        MoveObstacle();
    }

    void MoveObstacle()
    {
        // Move the obstacle left or right
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        // Check if the obstacle reached the right boundary
        if (transform.position.x >= rightBoundary)
        {
            movingRight = false; // Start moving left
        }
        // Check if the obstacle reached the left boundary
        else if (transform.position.x <= leftBoundary)
        {
            movingRight = true; // Start moving right
        }
    }
}
