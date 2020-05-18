using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHealth;
    public int currHealth;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    private bool lookingRight;


    // Start is called before the first frame update
    void Start()
    {
        lookingRight = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        } else
        {
            lookingRight = true;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0) {
            if (lookingRight)
            {
                GameObject projectileObject = Instantiate(projectile, transform.position + Vector3.right * 1f + Vector3.up * 0.5f, Quaternion.identity);
                //Projectile proj = projectileObject.GetComponent<Projectile>();
                //proj.Launch(new Vector2(1, 0), 300);
                timeBtwShots = startTimeBtwShots;
            } 
            else
            {
                GameObject projectileObject = Instantiate(projectile, transform.position + Vector3.left * 1f + Vector3.up * 0.5f, Quaternion.identity);
                //Projectile proj = projectileObject.GetComponent<Projectile>();
                //proj.Launch(new Vector2(-1, 0), 300);
                timeBtwShots = startTimeBtwShots;
            }
        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
