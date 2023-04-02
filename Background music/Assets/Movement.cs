using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    private bool isGrounded = true;
    public float jumpForce = 15f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }

        //space to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
            isGrounded = false;
        }

        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
