using UnityEngine;

public class AIpaddle : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the AI paddle
    public Transform ball; // Reference to the ball's transform

    void Update()
    {
        // Calculate the direction to move based on the ball's position
        float direction = Mathf.Sign(ball.position.y - transform.position.y);

        // Move the paddle towards the ball's y-position
        transform.Translate(Vector2.up * direction * speed * Time.deltaTime);
    }

   
}
