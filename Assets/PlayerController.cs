using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;

    Rigidbody2D rb;
    SpriteRenderer sr;
    float direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ADD JUMP AFTER COLLISIONS
        direction = Input.GetAxis("Horizontal");
        if (direction < 0)
        {
            sr.flipX = true;
        }
        else if (direction > 0)
        {
            sr.flipX = false;
        }
        Vector2 pos = rb.position;
        pos.x += direction * speed * Time.deltaTime;

        rb.MovePosition(pos);
    }
}
