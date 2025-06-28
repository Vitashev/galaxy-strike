using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText; // Reference to the UI Text component to display the score
    int score = 0; // Player's score

    // Method to increase the score
    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score increased by " + amount + ". Total score: " + score);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
