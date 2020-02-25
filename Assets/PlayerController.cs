using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;

    Rigidbody2D rb;
    float direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ADD JUMP AFTER COLLISIONS
        direction = Input.GetAxis("Horizontal");

        Vector2 pos = rb.position;
        pos.x += direction * speed * Time.deltaTime;

        rb.MovePosition(pos);
    }
}
