using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject gameOverScreen;
    public static int health = 20;

    public void Update()
    {
        if (health > 0)
        {
            text.SetText("HP : " + health);
        }
        else
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 1f;
        health = 20;
    }
}
