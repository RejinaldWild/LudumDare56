using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVictoryManager : MonoBehaviour
{
    public GameObject victoryScreen;  // ������ �� ����� ������

    private void OnEnable()
    {
        TestScoreManager.OnVictory += HandleVictory;  // ������������� �� ������� ������
    }

    private void OnDisable()
    {
        
        TestScoreManager.OnVictory -= HandleVictory; // ������������ �� ������� ������
    }

    private void HandleVictory()
    {
        Debug.Log("������! ���� �����������.");
        victoryScreen.SetActive(true);  
        Time.timeScale = 0f;  // ������������� ����
    }
}
