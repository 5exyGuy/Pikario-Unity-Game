using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;

    public float projectileTimer = 1.0f;

    float currTime;

    // Awake is called after the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        currTime = projectileTimer;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject e = other.gameObject;
        if (e != null)
        {
            Destroy(e);
        }

        Destroy(gameObject);
    }
}
