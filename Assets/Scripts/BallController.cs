using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
      public Text player1ScoreText; // Reference to Player 1's score Text
    public Text player2ScoreText; // Reference to Player 2's score Text
    public Text gameOverText; // Reference to Game Over Text

    public float speed = 10f; // Speed of the ball
    private Rigidbody2D rb;

    public float startX = 0f;
    public float startY = 4f; // Starting position of the ball

    private int player1Score = 0; // Player 1's score
    private int player2Score = 0; // Player 2's score
    private int scoreLimit = 20; // The score limit

    private bool gameOver = false; // Track if the game is over
    public Button restartButton; // Reference to the Restart Button

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
        player1ScoreText.text = "" + player1Score.ToString();
        player2ScoreText.text = "" + player2Score.ToString();
        gameOverText.gameObject.SetActive(false); // Hide the "Game Over" message initially
        restartButton.gameObject.SetActive(false); // Hide the Restart Button initially
    }

    // Launches the ball at the start of the game
    void LaunchBall()
    {
        // Randomize initial direction (either -1 or 1 for x and y)
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        // Set the initial velocity with the desired speed
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    // Resets the ball to the starting position
    void ResetBall()
    {
        transform.position = new Vector2(startX, startY);
        rb.velocity = Vector2.zero;
        LaunchBall();
    }

    // Update the score for Player 1
    void UpdatePlayer1Score()
    {
        player1Score++; // Increment Player 1's score
        player1ScoreText.text = player1Score.ToString(); // Update the UI

        // Check if Player 1 has won
        if (player1Score >= scoreLimit)
        {
            gameOverText.text = "Player 1 Wins!";
            gameOverText.gameObject.SetActive(true); // Display "Player 1 Wins!" message
            StopGame(); // Stop the game
        }
    }

    // Update the score for Player 2
    void UpdatePlayer2Score()
    {
        player2Score++; // Increment Player 2's score
        player2ScoreText.text = player2Score.ToString(); // Update the UI

        // Check if Player 2 has won
        if (player2Score >= scoreLimit)
        {
            gameOverText.text = "Player 2 Wins!";
            gameOverText.gameObject.SetActive(true); // Display "Player 2 Wins!" message
            StopGame(); // Stop the game
        }
    }

    // Stops the game by freezing ball movement and stopping further interactions
    void StopGame()
    {
        gameOver = true; // Set game to over
        rb.velocity = Vector2.zero; // Stop the ball immediately
        Time.timeScale = 0; // Pause the game (optional)
        restartButton.gameObject.SetActive(true); // Show the restart button when the game ends
    }

    // Handles collisions with paddles and walls
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameOver) return; // If the game is over, no further collision logic is executed

        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Determine where the ball hit the paddle
            float hitPoint = transform.position.y - collision.transform.position.y;
            float paddleHeight = collision.collider.bounds.size.y;

            // Calculate bounce direction
            float bounceDirection = hitPoint / (paddleHeight / 2);

            // Apply bounce with adjusted direction
            Vector2 newVelocity = new Vector2(-rb.velocity.x, bounceDirection * speed).normalized * speed;

            // Avoid re-entering the paddle by ensuring the velocity directs the ball away
            rb.velocity = newVelocity;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // Update scores based on which wall is hit
            if (collision.gameObject.name == "WestWall")
            {
                UpdatePlayer2Score(); // Player 2 scores
                Debug.Log($"Player 2 Scores! Player 1: {player1Score}, Player 2: {player2Score}");
            }
            else if (collision.gameObject.name == "EastWall")
            {
                UpdatePlayer1Score(); // Player 1 scores
                Debug.Log($"Player 1 Scores! Player 1: {player1Score}, Player 2: {player2Score}");
            }

            // Reset the ball after a goal if the game is not over
            if (!gameOver) ResetBall();
        }
    }

    // Resets the game (called when the restart button is pressed)
    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
        // Reset game variables
        player1Score = 0;
        player2Score = 0;
        player1ScoreText.text = "0";
        player2ScoreText.text = "0";

        // Hide the "Game Over" message and the restart button
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Reset the game state
        gameOver = false;
        ResetBall(); // Reset the ball position and velocity
        Time.timeScale = 1; // Resume the game
    }
}