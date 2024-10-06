using TMPro;
using UnityEngine;
using System;

public class TestScoreManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;  // ������ �� ��������� Text
    public static event Action OnVictory;  // ������� ������

    private void OnEnable()
    {
        // �������� ������ ����������� ��� ������� �����, � �� ����� �����
        TestEnemySpawner.OnEnemySpawned += OnEnemySpawned;  // ������������� �� ������� ������ ������
    }

    private void OnDisable()
    {
        TestEnemySpawner.OnEnemySpawned -= OnEnemySpawned;  // ������������ ��� ����������
    }

    // ���� ����� ����� ���������� ��� ������ ������ �����
    private void OnEnemySpawned(TestEnemy enemy)
    {
        enemy.OnEnemyDeath += AddScore;  // ������������� �� ������� ������ ����������� �����
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

    // ����� ��� ��������� �������� �����
    public int GetScore()
    {
        return score;
    }
}
