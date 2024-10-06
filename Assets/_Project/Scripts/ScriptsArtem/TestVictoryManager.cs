using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVictoryManager : MonoBehaviour
{
    public GameObject victoryScreen;  // Ссылка на экран победы

    private void OnEnable()
    {
        TestScoreManager.OnVictory += HandleVictory;  // Подписываемся на событие победы
    }

    private void OnDisable()
    {
        
        TestScoreManager.OnVictory -= HandleVictory; // Отписываемся от события победы
    }

    private void HandleVictory()
    {
        Debug.Log("Победа! Игра остановлена.");
        victoryScreen.SetActive(true);  
        Time.timeScale = 0f;  // Останавливаем игру
    }
}
