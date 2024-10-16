using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f; // �������� �����
    public int strength = 5;   // ���� ����� �����
    public int scoreValue = 10; // ���� �� �������� �����
    public GameObject lootPrefab; // �������, ������� ������� ����� ������
    public float moveSpeed = 2f; // �������� �������� �����

    private PlayerController player; // ��� ��������� � ������
    private Transform playerTransform; // ������� ������

    void Start()
    {
        player = FindObjectOfType<PlayerController>(); // ����� ������ �� �����
        playerTransform = player.transform; // �������� ��������� ������
    }

    void Update()
    {
        MoveTowardsPlayer(); // ��������� � ������
    }

    public void TakeDamage(float damage)
    {
        health -= damage; // ��������� �����
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        player.AddScore(scoreValue); // �������� ���� �� �������� �����
        DropLoot(); // ��������� ��������
        Destroy(gameObject); // �������� �����
    }

    void DropLoot()
    {
        if (lootPrefab != null)
        {
            Instantiate(lootPrefab, transform.position, Quaternion.identity); // ������� ������� �� ����� ������
        }
    }

    // ������ ����������� ����� � ������
    void MoveTowardsPlayer()
    {
        if (playerTransform != null)
        {
            // ������������ ����������� � ������
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            // ���������� ����� � ������ � ������������ ���������
            transform.position += direction * moveSpeed * Time.deltaTime;

            // ������� ����� � ������� ������
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}