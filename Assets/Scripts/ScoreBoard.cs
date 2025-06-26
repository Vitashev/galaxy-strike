using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score = 0; // Player's score

    // Method to increase the score
    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score increased by " + amount + ". Total score: " + score);
    }
}
