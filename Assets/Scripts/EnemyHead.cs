using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    GameObject enemy;
    
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(enemy);
    }
}
