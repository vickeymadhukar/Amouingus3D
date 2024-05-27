using UnityEngine;

public class check : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystk;
    private Animator anime;
    public float speed = 5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector3(joystk.Horizontal * speed * Time.deltaTime, rb.velocity.y, joystk.Vertical * speed * Time.deltaTime);
        anime.SetBool("isruning", true);
    }
}
