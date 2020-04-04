using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool isPaused;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Transition to a pause
            if (!isPaused)
            {
                Time.timeScale = 0;
                audio.Pause();
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                audio.UnPause();
                isPaused = false;
            }
        }
    }
}
