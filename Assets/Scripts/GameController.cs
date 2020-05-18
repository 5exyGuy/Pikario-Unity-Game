using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Image pauseMenu;
    public Image deathScreen;
    public GameObject pikario;

    bool isPaused;
    AudioSource audio;
    PlayerController controller;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        audio = GetComponent<AudioSource>();
        pauseMenu.enabled = false;
        controller = pikario.GetComponent<PlayerController>();
        timer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        //if pikario health is zero, end the game
        if (controller.GetPlayerHealth() <= 0)
        {
            deathScreen.enabled = true;
            audio.Stop();
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Transition to a pause
            if (isPaused)
            {
                //Unpause
                Time.timeScale = 1;
                audio.UnPause();
                isPaused = false;
                pauseMenu.enabled = false;
            }
            else
            {
                //Pause
                Time.timeScale = 0;
                audio.Pause();
                isPaused = true;
                pauseMenu.enabled = true;
            }
        }
    }
}
