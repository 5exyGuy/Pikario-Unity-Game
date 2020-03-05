using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    public float jumpForce = 20f;
    public GameObject raySource;

    Rigidbody2D rb;
    Animator anim;
    float horizontal;
    RaycastHit2D grounded;

    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // Moving 
        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);

        UpdateAnimations();
    }

    private bool IsGrounded()
    {
        grounded = Physics2D.Raycast(raySource.transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        return grounded.collider != null;
    }

    private void UpdateAnimations()
    {
        Vector2 move = new Vector2(horizontal, 0);
        if (!Mathf.Approximately(horizontal, 0.0f)) // Saves the looking direction for better animation control
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        // Setting the animations
        anim.SetFloat("Move X", lookDirection.x);
        anim.SetFloat("Speed", move.magnitude);
    }
}
