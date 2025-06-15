using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");  // Input brut pour éviter l’inertie input
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized * speed;

        Vector3 velocity = rb.linearVelocity;
        velocity.x = move.x;
        velocity.z = move.z;

        rb.linearVelocity = velocity;
    }
}
