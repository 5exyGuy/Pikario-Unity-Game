using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectible : MonoBehaviour
{
    public AudioClip collectedClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pikario = other.GetComponent<PlayerController>();
        if (pikario != null)
        {
            pikario.ChangeScore(10);
            pikario.PlaySound(collectedClip);
            Destroy(gameObject);
        }
    }
}
