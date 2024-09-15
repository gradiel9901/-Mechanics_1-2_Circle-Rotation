using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For reloading the scene in case of game over
using TMPro; // For using TextMeshPro

public class RotatingMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f; // Speed of rotation
    [SerializeField] private Transform rotateAround; // The dog (around which the cat rotates)
    [SerializeField] private TextMeshProUGUI scoreText; // TextMeshPro UI element for displaying the score

    private bool rotateClockwise = true; // Whether the rotation is clockwise
    private bool gameStarted = false; // Whether the game has started
    private int score = 0; // Player's score

    void Start()
    {
        UpdateScoreText(); // Initialize the score display
    }

    void Update()
    {
        // Start the game when space is pressed for the first time
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
            }
            return; // Wait until the game starts
        }

        // Toggle clockwise/counterclockwise rotation on space press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotateClockwise = !rotateClockwise;
        }

        // Rotate the cat around the dog
        if (rotateClockwise)
        {
            this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.RotateAround(rotateAround.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
    }

    // Handle collisions with points and obstacles
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            // Increase the score when colliding with a point (cube)
            score += 1;
            Debug.Log("Score: " + score);
            Destroy(collision.gameObject); // Destroy the point after collecting
            UpdateScoreText(); // Update the score display
        }
        else if (collision.CompareTag("Obstacle"))
        {
            // Game over logic when colliding with an obstacle
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene
        }
    }

    // Update the UI score text using TextMeshPro
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
