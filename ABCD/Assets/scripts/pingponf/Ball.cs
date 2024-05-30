using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Scoremanager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<Scoremanager>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 direction = new Vector2(x, y);
        rb.velocity = direction.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            Vector2 vel = rb.velocity;
            vel.y = vel.y + (collision.collider.attachedRigidbody.velocity.y / 2);
            rb.velocity = vel;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GoalPlayer")
        {
            scoreManager.AIScores();
        }
        else if (other.gameObject.tag == "GoalAI")
        {
            scoreManager.PlayerScores();
        }
    }
}
