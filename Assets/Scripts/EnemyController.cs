using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //can do a switch or sth thingy where it selects the movement depending on the enemy type
    public AudioClip attackClip;
    public AudioClip deathClip;

    public float speed = 2.0f;
    public bool movingRight = true;
    public float time = 2.0f;
    private float timeLeft = 2.0f;

    void Update()
    {
        if (timeLeft < 0) {
            movingRight = !movingRight;
            timeLeft = time;
        }

        if (movingRight) {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
            timeLeft -= Time.deltaTime;
        }
        else 
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
            timeLeft -= Time.deltaTime;
        }
    }

    void Start()
    {
        timeLeft = time;
    }
}
