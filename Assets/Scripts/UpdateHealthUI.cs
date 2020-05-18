using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// Attach to an empty GameObject
// To initialize script on a new scene, add updateHealthUI() in the Awake or Start Method of your player
// Then just use this script in your OnCollision method using thisScript.Health --
public class UpdateHealthUI : MonoBehaviour // MonoBehaviour
{

    // Insert your 3 hearts images in the Unity Editor
    [SerializeField] private Image h1, h2, h3;
    public Sprite fullHeart, emptyHeart;
    // Create an array because we're lazy
    private Image[] images;
    // Gameover
    //[SerializeField] private Image gameOver;
    // A private variable to keep between scenes
    // Now we define Get / Set methods for health
    // In case we Set health to a different value we want to update UI

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        images = new Image[] { h1, h2, h3 };
    }

    public void updateHealthUI(int currHealth)
    {
        for (int i = 0; i < images.Length; i++)
        {
            // Hide all images superior to the newHealth
            if (i >= currHealth)
                images[i].sprite = emptyHeart;
            else
                images[i].sprite = fullHeart;
        }
        // Game Over
    }

}