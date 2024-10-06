using TMPro;
using UnityEngine;
using System;

public class TestScoreManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;  // ������ �� ��������� Text
    public static event Action OnVictory;  // ������� ������

    private void OnEnable() // ������������� �� ������� ��� ������
    {
        Debug.Log("ScoreManager ���������� �� ������� ������ �����.");
        TestEnemy.OnEnemyDeath += AddScore;
    }

    private void OnDisable() // ������������ ��� ���������� �������
    {
        TestEnemy.OnEnemyDeath -= AddScore;
    }

    private void Start()
    {
        UpdateScoreText(); 
    }
    private void AddScore() // ���� ����
    {
        score++;
        Debug.Log("������� ������ ����� ���������, ��������� ����. ������� ����: " + score);
        Debug.Log("Score: " + score);
        UpdateScoreText();
        
        if (score >= 5)
        {
            OnVictory?.Invoke();  // ����� ������� ������, ���� ���� ����������
        }
    }
    private void UpdateScoreText()  // ����� ��� ���������� ������
    {
        scoreText.text = "Score: " + score;
    }
}
