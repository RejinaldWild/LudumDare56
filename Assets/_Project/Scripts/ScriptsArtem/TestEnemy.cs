using System;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public event Action OnEnemyDeath; // Событие для смерти врага
    public float moveSpeed = 2f;  // Скорость движения врага
    public float turnSpeed = 1f;  // Скорость поворота врага

    private Vector2 movementDirection;  // Текущее направление движения
    private float changeDirectionInterval = 2f;  // Интервал смены направления
    private float timeSinceLastDirectionChange = 0f;  // Время с момента последней смены направления

    // Ограничения по координатам X и Y
    [SerializeField] private float minX = -25f;
    [SerializeField] private float maxX = 25f;
    [SerializeField] private float minY = -15f;
    [SerializeField] private float maxY = 15f;

    private void Start()
    {
        ChangeDirection();  // Задаем начальное направление
    }

    private void Update()
    {
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World); // Движение врага в выбранном направлении

        timeSinceLastDirectionChange += Time.deltaTime; // Логика смены направления каждые 2 секунды
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeDirection();  // Меняем направление
            timeSinceLastDirectionChange = 0f;  // Сбрасываем таймер
        }

        CheckBounds(); // Проверяем, не вышел ли враг за границы поля, и изменяем направление
    }

    private void ChangeDirection() // Метод для смены направления
    {
        Vector2 newDirection = UnityEngine.Random.insideUnitCircle.normalized; // Случайное новое направление
        StartCoroutine(SmoothRotation(newDirection)); // Плавный поворот с помощью Lerp
        movementDirection = newDirection; // Задаем новое направление
    }

    private System.Collections.IEnumerator SmoothRotation(Vector2 newDirection) // Метод для плавного поворота врага в новом направлении
    {
        float timeElapsed = 0f;
        Quaternion startRotation = transform.rotation;  // Начальное вращение
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, newDirection);  // Цель вращения

        while (timeElapsed < 1f)
        {
            // Плавное изменение угла вращения
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeElapsed / 1f);
            timeElapsed += Time.deltaTime * turnSpeed;
            yield return null;
        }
        transform.rotation = targetRotation;  // Устанавливаем конечный угол вращения
    }

    private void CheckBounds()     // Проверка, не вышел ли враг за пределы поля, и смена направления при выходе за границы
    {
        Vector3 position = transform.position;

        if (position.x < minX || position.x > maxX || position.y < minY || position.y > maxY)
        {
            // Меняем направление на противоположное
            movementDirection = -movementDirection;

            // Плавно разворачиваем врага
            StartCoroutine(SmoothRotation(movementDirection));
        }
    }

    public void Die()
    {
        if (OnEnemyDeath != null)
        {
            Debug.Log("Враг умирает. Событие смерти вызвано.");
            OnEnemyDeath.Invoke();  // Вызов события
        }
        Destroy(gameObject);
    }
}