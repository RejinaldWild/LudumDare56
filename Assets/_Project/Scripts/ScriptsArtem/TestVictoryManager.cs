using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Для отображения текста

public class TestVictoryManager : MonoBehaviour
{
    public GameObject victoryScreen;  // Ссылка на экран победы
    public TextMeshProUGUI finalScoreText;  // Ссылка на текст для отображения итогового счёта
    public Image playerHealthImage;   // Ссылка на изображение для отображения состояния здоровья игрока

    private TestPlayerStatusUI playerStatusUI;  // Ссылка на скрипт для отображения здоровья
    private TestScoreManager scoreManager;  // Ссылка на менеджер счёта

    private void Start()
    {
        // Найдём компоненты на сцене
        playerStatusUI = FindObjectOfType<TestPlayerStatusUI>();
        scoreManager = FindObjectOfType<TestScoreManager>();

        // Убедимся, что экран победы скрыт
        victoryScreen.SetActive(false);
    }

    private void OnEnable()
    {
        TestScoreManager.OnVictory += HandleVictory;  // Подписываемся на событие победы
    }

    private void OnDisable()
    {
        TestScoreManager.OnVictory -= HandleVictory;  // Отписываемся от события победы
    }

    private void HandleVictory()
    {
        Debug.Log("Победа! Игра остановлена.");
        victoryScreen.SetActive(true);  // Показываем экран победы
        Time.timeScale = 0f;  // Останавливаем игру

        // Отображаем итоговый счёт
        finalScoreText.text = "Final Score: " + scoreManager.GetScore();

        // Обновляем картинку здоровья игрока
        playerHealthImage.sprite = playerStatusUI.GetCurrentHealthSprite();
    }

    public void HandleDefeat()
    {
        Debug.Log("Игра окончена. Проигрыш.");
        victoryScreen.SetActive(true);  // Показываем экран
        finalScoreText.text = "Final Score: " + scoreManager.GetScore();  // Отображаем итоговый счёт
        Time.timeScale = 0f;  // Останавливаем игру
    }
}
