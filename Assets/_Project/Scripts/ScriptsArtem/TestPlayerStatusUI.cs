using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerStatusUI : MonoBehaviour
{
    public Image playerStatusImage;     // UI-элемент для отображения состояния игрока
    public Sprite[] playerStatusSprites; // Массив картинок для разных состояний игрока
    public TextMeshProUGUI damageText;

    [SerializeField] private int normHP = 5;
    [SerializeField] private int hitHP = 10;
    [SerializeField] private int moreHitHp = 15;
    [SerializeField] private int EndHit = 20;
    // private int endHP = 0;

    private TestEnemySpawner enemySpawner;  // Ссылка на спавнер врагов

    private void Start()
    {
        enemySpawner = FindObjectOfType<TestEnemySpawner>();

        if (enemySpawner != null)
        {
            UnityEngine.Debug.Log("Спавнер врагов найден.");
            TestEnemySpawner.OnEnemyCountChanged += UpdatePlayerStatusUI;
            UnityEngine.Debug.Log("Подписались на событие изменения количества врагов.");
        }
        else
        {
            UnityEngine.Debug.LogError("Спавнер врагов не найден!");
        }
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        TestEnemySpawner.OnEnemyCountChanged -= UpdatePlayerStatusUI;
    }

    private void UpdatePlayerStatusUI()
    {
        UnityEngine.Debug.Log("Событие OnEnemyCountChanged получено в TestPlayerStatusUI.");
        int enemyCount = enemySpawner.GetEnemyCount();
        UnityEngine.Debug.Log("Количество врагов: " + enemyCount);
        if (enemyCount < normHP)
        {
            playerStatusImage.sprite = playerStatusSprites[0];  // Первая картинка
        }
        else if (enemyCount < hitHP)
        {
            UnityEngine.Debug.Log("Меняем спрайт на первый");
            playerStatusImage.sprite = playerStatusSprites[1];  // Вторая картинка
        }
        else if (enemyCount < moreHitHp)
        {
            UnityEngine.Debug.Log("Меняем спрайт на второй");
            playerStatusImage.sprite = playerStatusSprites[2];  // Третья картинка
        }
        else if (enemyCount >= EndHit)
        {
            TriggerGameOver();  // Проигрыш при достижении 20 врагов
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
            return playerStatusSprites[3];  // Последний спрайт для проигрыша
        }
    }


        // Метод для обработки проигрыша
        private void TriggerGameOver()
    {
        UnityEngine.Debug.Log("Игра окончена! Слишком много врагов.");

        FindObjectOfType<TestVictoryManager>().HandleDefeat();
    }
}