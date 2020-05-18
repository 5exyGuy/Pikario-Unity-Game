﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController pikario = col.gameObject.GetComponent<PlayerController>();
        if (pikario != null)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
