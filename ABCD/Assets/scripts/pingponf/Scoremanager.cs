using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public int playerScore = 0;
    public int aiScore = 0;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;
   
    public Transform ball;

    public void PlayerScores()
    {
        playerScore++;
        UpdateScore();
        ResetBall();
    }

    public void AIScores()
    {
        aiScore++;
        UpdateScore();
        ResetBall();
    }

    void UpdateScore()
    {
        playerScoreText.text = playerScore.ToString();
        aiScoreText.text = aiScore.ToString();
    }

    void ResetBall()
    {
        ball.position = Vector3.zero;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Optionally, wait for a second before launching the ball
        Invoke("LaunchBall", 1.0f);
    }

    void LaunchBall()
    {
        ball.GetComponent<Ball>().LaunchBall();
    }
}
