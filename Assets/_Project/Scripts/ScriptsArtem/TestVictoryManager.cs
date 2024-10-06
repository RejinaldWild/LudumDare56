using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // ��� ����������� ������

public class TestVictoryManager : MonoBehaviour
{
    public GameObject victoryScreen;  // ������ �� ����� ������
    public TextMeshProUGUI finalScoreText;  // ������ �� ����� ��� ����������� ��������� �����
    public Image playerHealthImage;   // ������ �� ����������� ��� ����������� ��������� �������� ������

    private TestPlayerStatusUI playerStatusUI;  // ������ �� ������ ��� ����������� ��������
    private TestScoreManager scoreManager;  // ������ �� �������� �����

    private void Start()
    {
        // ����� ���������� �� �����
        playerStatusUI = FindObjectOfType<TestPlayerStatusUI>();
        scoreManager = FindObjectOfType<TestScoreManager>();

        // ��������, ��� ����� ������ �����
        victoryScreen.SetActive(false);
    }

    private void OnEnable()
    {
        TestScoreManager.OnVictory += HandleVictory;  // ������������� �� ������� ������
    }

    private void OnDisable()
    {
        TestScoreManager.OnVictory -= HandleVictory;  // ������������ �� ������� ������
    }

    private void HandleVictory()
    {
        Debug.Log("������! ���� �����������.");
        victoryScreen.SetActive(true);  // ���������� ����� ������
        Time.timeScale = 0f;  // ������������� ����

        // ���������� �������� ����
        finalScoreText.text = "Final Score: " + scoreManager.GetScore();

        // ��������� �������� �������� ������
        playerHealthImage.sprite = playerStatusUI.GetCurrentHealthSprite();
    }

    public void HandleDefeat()
    {
        Debug.Log("���� ��������. ��������.");
        victoryScreen.SetActive(true);  // ���������� �����
        finalScoreText.text = "Final Score: " + scoreManager.GetScore();  // ���������� �������� ����
        Time.timeScale = 0f;  // ������������� ����
    }
}
