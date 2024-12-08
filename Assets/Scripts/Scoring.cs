using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text player1ScoreText; // Reference to Player 1's score Text
    public Text player2ScoreText; // Reference to Player 2's score Text

    private int player1Score = 0; // Player 1's score
    private int player2Score = 0; // Player 2's score

    // Update the score for Player 1
    public void UpdatePlayer1Score()
    {
        player1Score++; // Increment Player 1's score
        player1ScoreText.text = player1Score.ToString(); // Update the UI
    }

    // Update the score for Player 2
    public void UpdatePlayer2Score()
    {
        player2Score++; // Increment Player 2's score
        player2ScoreText.text = player2Score.ToString(); // Update the UI
    }
}
