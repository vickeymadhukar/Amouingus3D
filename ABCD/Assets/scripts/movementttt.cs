using UnityEngine;

public class movementttt : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystk;
    private Animator animator;
    public float moveSpeed = 10f;
    public float rotationSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
        UpdateAnimator();
    }

    private void HandleMovement()
    {
        rb.velocity = new Vector3(joystk.Horizontal * moveSpeed * Time.deltaTime, rb.velocity.y, joystk.Vertical * moveSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        float horizontalInput = joystk.Horizontal;
        float verticalInput = joystk.Vertical;

        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            Vector3 targetDirection = new Vector3(horizontalInput, 0f, verticalInput);
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(newRotation);
        }
    }

    private void UpdateAnimator()
    {
        bool isRunning = Mathf.Abs(joystk.Horizontal) > 0.1f || Mathf.Abs(joystk.Vertical) > 0.1f;

        animator.SetBool("isruning", isRunning);
    }
}
