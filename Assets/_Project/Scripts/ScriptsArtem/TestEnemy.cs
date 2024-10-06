using System;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public event Action OnEnemyDeath; // ������� ��� ������ �����
    public float moveSpeed = 2f;  // �������� �������� �����
    public float turnSpeed = 1f;  // �������� �������� �����

    private Vector2 movementDirection;  // ������� ����������� ��������
    private float changeDirectionInterval = 2f;  // �������� ����� �����������
    private float timeSinceLastDirectionChange = 0f;  // ����� � ������� ��������� ����� �����������

    // ����������� �� ����������� X � Y
    [SerializeField] private float minX = -25f;
    [SerializeField] private float maxX = 25f;
    [SerializeField] private float minY = -15f;
    [SerializeField] private float maxY = 15f;

    private void Start()
    {
        ChangeDirection();  // ������ ��������� �����������
    }

    private void Update()
    {
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World); // �������� ����� � ��������� �����������

        timeSinceLastDirectionChange += Time.deltaTime; // ������ ����� ����������� ������ 2 �������
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeDirection();  // ������ �����������
            timeSinceLastDirectionChange = 0f;  // ���������� ������
        }

        CheckBounds(); // ���������, �� ����� �� ���� �� ������� ����, � �������� �����������
    }

    private void ChangeDirection() // ����� ��� ����� �����������
    {
        Vector2 newDirection = UnityEngine.Random.insideUnitCircle.normalized; // ��������� ����� �����������
        StartCoroutine(SmoothRotation(newDirection)); // ������� ������� � ������� Lerp
        movementDirection = newDirection; // ������ ����� �����������
    }

    private System.Collections.IEnumerator SmoothRotation(Vector2 newDirection) // ����� ��� �������� �������� ����� � ����� �����������
    {
        float timeElapsed = 0f;
        Quaternion startRotation = transform.rotation;  // ��������� ��������
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, newDirection);  // ���� ��������

        while (timeElapsed < 1f)
        {
            // ������� ��������� ���� ��������
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeElapsed / 1f);
            timeElapsed += Time.deltaTime * turnSpeed;
            yield return null;
        }
        transform.rotation = targetRotation;  // ������������� �������� ���� ��������
    }

    private void CheckBounds()     // ��������, �� ����� �� ���� �� ������� ����, � ����� ����������� ��� ������ �� �������
    {
        Vector3 position = transform.position;

        if (position.x < minX || position.x > maxX || position.y < minY || position.y > maxY)
        {
            // ������ ����������� �� ���������������
            movementDirection = -movementDirection;

            // ������ ������������� �����
            StartCoroutine(SmoothRotation(movementDirection));
        }
    }

    public void Die()
    {
        if (OnEnemyDeath != null)
        {
            Debug.Log("���� �������. ������� ������ �������.");
            OnEnemyDeath.Invoke();  // ����� �������
        }
        Destroy(gameObject);
    }
}