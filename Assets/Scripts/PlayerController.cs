using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    public float jumpForce = 20f;
    public int maxHealth = 3;
    public GameObject raySource;
    public TextMeshProUGUI scoreText;
    public GameObject lightningPrefab;

    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D collider;
    float horizontal;
    int score;
    public int currHealth;
    RaycastHit2D grounded;
    AudioSource audioSource;
    UpdateHealthUI healthScript;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        healthScript = GetComponentInChildren<UpdateHealthUI>();
        score = 0;
        currHealth = maxHealth;
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

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
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

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void ResetPlayer(Vector2 respawn)
    {
        rb.position = respawn; // Respawn point
        rb.velocity = new Vector2(0, 0);
    }

    public void ChangeHealth(int amount)
    {
        if (isInvincible) return;

        currHealth = Mathf.Max(0, currHealth + amount);
        currHealth = Mathf.Min(currHealth, maxHealth);
        // Update health
        healthScript.updateHealthUI(currHealth);
    }

    private void Launch()
    {
        GameObject projectileObject = Instantiate(lightningPrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

    }

    public int GetPlayerHealth()
    {
        return currHealth;
    }
}
