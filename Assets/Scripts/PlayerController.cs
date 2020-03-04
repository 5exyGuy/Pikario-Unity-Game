using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;

    Rigidbody2D rb;
    Animator anim;
    float horizontal;

    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ADD JUMP AFTER COLLISIONS
        horizontal = Input.GetAxis("Horizontal");

        Vector2 move = new Vector2(horizontal, 0);
        if(!Mathf.Approximately(horizontal, 0.0f)) // Saves the looking direction for better animation control
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        anim.SetFloat("Move X", lookDirection.x);
        anim.SetFloat("Speed", move.magnitude);

        Vector2 pos = rb.position;
        pos.x += horizontal * speed * Time.deltaTime;

        rb.MovePosition(pos);
    }
}
