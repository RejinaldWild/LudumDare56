using TMPro;
using UnityEngine;
using System;

public class TestScoreManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;  // Ссылка на компонент Text
    public static event Action OnVictory;  // Событие победы

    private void OnEnable()
    {
        // Подписка должна происходить для каждого врага, а не через класс
        TestEnemySpawner.OnEnemySpawned += OnEnemySpawned;  // Подписываемся на событие спавна врагов
    }

    private void OnDisable()
    {
        TestEnemySpawner.OnEnemySpawned -= OnEnemySpawned;  // Отписываемся при отключении
    }

    // Этот метод будет вызываться при спавне нового врага
    private void OnEnemySpawned(TestEnemy enemy)
    {
        enemy.OnEnemyDeath += AddScore;  // Подписываемся на событие смерти конкретного врага
    }

    private void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Метод для получения текущего счёта
    public int GetScore()
    {
        return score;
    }
}
