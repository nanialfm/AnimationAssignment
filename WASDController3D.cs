using UnityEngine;

public class WASDController3D : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 7f;

    Rigidbody rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A/D + Left/Right
        float z = Input.GetAxis("Vertical");   // W/S + Up/Down

        rb.linearVelocity = new Vector3(x * moveSpeed, rb.linearVelocity.y, z * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
