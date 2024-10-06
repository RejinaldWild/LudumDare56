using TMPro;
using UnityEngine;
using System;

public class TestScoreManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;  // Ссылка на компонент Text
    public static event Action OnVictory;  // Событие победы

    private void OnEnable() // Подписываемся на событие при старте
    {
        Debug.Log("ScoreManager подписался на событие смерти врага.");
        TestEnemy.OnEnemyDeath += AddScore;
    }

    private void OnDisable() // Отписываемся при отключении объекта
    {
        TestEnemy.OnEnemyDeath -= AddScore;
    }

    private void Start()
    {
        UpdateScoreText(); 
    }
    private void AddScore() // плюс счет
    {
        score++;
        Debug.Log("Событие смерти врага сработало, добавляем очко. Текущий счёт: " + score);
        Debug.Log("Score: " + score);
        UpdateScoreText();
        
        if (score >= 5)
        {
            OnVictory?.Invoke();  // Вызов события победы, если есть подписчики
        }
    }
    private void UpdateScoreText()  // Метод для обновления текста
    {
        scoreText.text = "Score: " + score;
    }
}
