using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    public float jumpForce = 20f;
    public GameObject raySource;
    public TextMeshProUGUI scoreText;

    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D collider;
    float horizontal;
    public int score;
    RaycastHit2D grounded;
    

    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        score = 0;
    }

    void Update()
    {
        // Input
        horizontal = Input.GetAxis("Horizontal");

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // Moving 
        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);

        // Animations
        UpdateAnimations();
    }

    private bool IsGrounded()
    {
        grounded = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
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
        anim.SetBool("Jumping", !IsGrounded());
        anim.SetFloat("Jump Velocity", rb.velocity.y);
    }

    public void ChangeScore(int amount)
    {
        score = Mathf.Max(0, score + amount); // Using max method so there wouldn't be negative score
        scoreText.text = "Score: " + score.ToString(); // Updated the score text on the UI
    }
}
