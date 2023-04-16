using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollusion : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    [Tooltip("Starting point of the object that it will be respawned at after death")] 
    [SerializeField] private Vector3 startPoint;

    [Tooltip("Images of player lives")] 
    [SerializeField] private Image[] livesImages;
    
    // Player's lives counter
    private int lives = 5;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Current object doesn't collide with the target
        if (!other.CompareTag(triggeringTag) || !enabled) return;
        
        // Update player lives
        lives--;
        UpdateLivesImages();

        // Respawn if there are more lives, otherwise finish game.
        if (lives == 0)
        {
            Debug.Log("Finish Game scene");
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
          Respawn(this.gameObject);   
        }
    }
    
    /**
     * Function updates the live images according to the amount of lives.
     */
    private void UpdateLivesImages()
    {
        for (int i = 0; i < livesImages.Length; i++)
        {
            if (i >= lives)
            {
                livesImages[i].enabled = false;
            }
        }
    }

    /**
     * Function respawns the player in start point
     */
    private void Respawn(GameObject player)
    {
        player.transform.position = startPoint;
    }
}
