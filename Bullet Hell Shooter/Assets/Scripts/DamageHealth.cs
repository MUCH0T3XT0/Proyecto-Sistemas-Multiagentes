using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI; // Add this namespace for UI components

using UnityEngine.SceneManagement;

using TMPro;

public class DamageHealth : MonoBehaviour
{
    public static event Action<float> OnHealthChanged;

    public float health = 100f; // Vida del enemigo

    public GameObject gameOverScreen; // Game Over screen GameObject
    public TextMeshProUGUI gameOverText; // Text component to display "You Died" message

    public GameObject victoryScreen; // Victory screen GameObject
    public TextMeshProUGUI victoryText;

    private float startTime;

    void Start()
    {
        OnHealthChanged?.Invoke(health);
        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
        startTime = Time.time;
    }

    // Método para recibir daño
    public void TakeDamage(float damage)
    {
        health -= damage;
        OnHealthChanged?.Invoke(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    // Método para destruir al enemigo
    void Die()
    {
        gameOverScreen.SetActive(true); // Show the Game Over screen
        gameOverText.text = "You Died"; // Set the text to "You Died"
        // You can add more effects, like playing a sound or animation, here
        // For now, let's just pause the game
        Time.timeScale = 0f;
        //Destroy(gameObject);
        // Wait for 5 seconds before restarting the game
        StartCoroutine(RestartGameCoroutine());
    }
    void Update()
    {
        // Check if the player has survived for 1 minute
        if (Time.time - startTime >= 60f && health > 0f)
        {
            Win();
        }
    }

    void Win()
    {
        victoryScreen.SetActive(true); // Show the Victory screen
        victoryText.text = "You Won!"; // Set the text to "You Won!"
        // You can add more effects, like playing a sound or animation, here
        // For now, let's just pause the game
        Time.timeScale = 0f;
        // Wait for 5 seconds before restarting the game
        StartCoroutine(RestartGameCoroutine());
    }
    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(5f);

        // Reset the game state
        health = 100f;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        // You can add more reset logic here, like resetting the player position, etc.
    }
}
