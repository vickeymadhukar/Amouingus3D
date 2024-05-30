using UnityEngine;

public class Playerpaddle : MonoBehaviour
{
    public float speed = 10.0f;  // Speed of the paddle

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Determine if touch is in the upper or lower half of the screen
            if (touch.position.y > Screen.height / 2)
            {
                // Move the paddle up
                MovePaddle(Vector2.up);
            }
            else
            {
                // Move the paddle down
                MovePaddle(Vector2.down);
            }
        }
    }

    void MovePaddle(Vector2 direction)
    {
        // Apply movement force to the paddle
        rb.velocity = direction * speed*10f;
    }

    
}
