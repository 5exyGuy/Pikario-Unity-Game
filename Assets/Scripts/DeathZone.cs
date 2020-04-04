using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public AudioClip diedClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pikario = other.GetComponent<PlayerController>();
        if (pikario != null)
        {
            pikario.PlaySound(diedClip);
            pikario.ResetPlayer(new Vector2(0, 0)); //Can add respawn places depending on the level
        }
    }
}
