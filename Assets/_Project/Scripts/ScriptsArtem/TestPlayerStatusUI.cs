using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerStatusUI : MonoBehaviour
{
    public Image playerStatusImage;     // UI-������� ��� ����������� ��������� ������
    public Sprite[] playerStatusSprites; // ������ �������� ��� ������ ��������� ������
    public TextMeshProUGUI damageText;

    [SerializeField] private int normHP = 5;
    [SerializeField] private int hitHP = 10;
    [SerializeField] private int moreHitHp = 15;
    [SerializeField] private int EndHit = 20;
    // private int endHP = 0;

    private TestEnemySpawner enemySpawner;  // ������ �� ������� ������

    private void Start()
    {
        enemySpawner = FindObjectOfType<TestEnemySpawner>();

        if (enemySpawner != null)
        {
            UnityEngine.Debug.Log("������� ������ ������.");
            TestEnemySpawner.OnEnemyCountChanged += UpdatePlayerStatusUI;
            UnityEngine.Debug.Log("����������� �� ������� ��������� ���������� ������.");
        }
        else
        {
            UnityEngine.Debug.LogError("������� ������ �� ������!");
        }
    }

    private void OnDestroy()
    {
        // ������������ �� ������� ��� ����������� �������
        TestEnemySpawner.OnEnemyCountChanged -= UpdatePlayerStatusUI;
    }

    private void UpdatePlayerStatusUI()
    {
        UnityEngine.Debug.Log("������� OnEnemyCountChanged �������� � TestPlayerStatusUI.");
        int enemyCount = enemySpawner.GetEnemyCount();
        UnityEngine.Debug.Log("���������� ������: " + enemyCount);
        if (enemyCount < normHP)
        {
            playerStatusImage.sprite = playerStatusSprites[0];  // ������ ��������
        }
        else if (enemyCount < hitHP)
        {
            UnityEngine.Debug.Log("������ ������ �� ������");
            playerStatusImage.sprite = playerStatusSprites[1];  // ������ ��������
        }
        else if (enemyCount < moreHitHp)
        {
            UnityEngine.Debug.Log("������ ������ �� ������");
            playerStatusImage.sprite = playerStatusSprites[2];  // ������ ��������
        }
        else if (enemyCount >= EndHit)
        {
            TriggerGameOver();  // �������� ��� ���������� 20 ������
        }
        damageText.text = "Damage: "+ enemyCount;

    }
    public Sprite GetCurrentHealthSprite()
    {
        int enemyCount = enemySpawner.GetEnemyCount();

        if (enemyCount < normHP)
        {
            return playerStatusSprites[0];
        }
        else if (enemyCount < hitHP)
        {
            return playerStatusSprites[1];
        }
        else if (enemyCount < moreHitHp)
        {
            return playerStatusSprites[2];
        }
        else
        {
            return playerStatusSprites[3];  // ��������� ������ ��� ���������
        }
    }


        // ����� ��� ��������� ���������
        private void TriggerGameOver()
    {
        UnityEngine.Debug.Log("���� ��������! ������� ����� ������.");

        FindObjectOfType<TestVictoryManager>().HandleDefeat();
    }
}