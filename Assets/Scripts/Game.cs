using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;
    // Player scores
    private int player1Score = 0;
    private int player2Score = 0;

    // Method to update the scoreboard
    private void UpdateScoreUI()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    // Method to increase Player 1's score
    public void AddScoreToPlayer1()
    {
        player1Score++;
        UpdateScoreUI();
    }

    // Method to increase Player 2's score
    public void AddScoreToPlayer2()
    {
        player2Score++;
        UpdateScoreUI();
    }

    // Optional: Reset scores (if needed)
    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateScoreUI();
    }
}
