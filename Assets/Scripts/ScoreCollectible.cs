using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pikario = other.GetComponent<PlayerController>();
        if (pikario != null)
        {
            pikario.ChangeScore(10);
            Destroy(gameObject);
        }
    }
}
