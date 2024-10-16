using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f; // Здоровье врага
    public int strength = 5;   // Сила удара врага
    public int scoreValue = 10; // Очки за убийство врага
    public GameObject lootPrefab; // Предмет, который выпадет после смерти
    public float moveSpeed = 2f; // Скорость движения врага

    private PlayerController player; // Для обращения к игроку
    private Transform playerTransform; // Позиция игрока

    void Start()
    {
        player = FindObjectOfType<PlayerController>(); // Найти игрока на сцене
        playerTransform = player.transform; // Получить трансформ игрока
    }

    void Update()
    {
        MoveTowardsPlayer(); // Двигаться к игроку
    }

    public void TakeDamage(float damage)
    {
        health -= damage; // Получение урона
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        player.AddScore(scoreValue); // Добавить очки за убийство врага
        DropLoot(); // Выпадение предмета
        Destroy(gameObject); // Удаление врага
    }

    void DropLoot()
    {
        if (lootPrefab != null)
        {
            Instantiate(lootPrefab, transform.position, Quaternion.identity); // Создать предмет на месте смерти
        }
    }

    // Логика перемещения врага к игроку
    void MoveTowardsPlayer()
    {
        if (playerTransform != null)
        {
            // Рассчитываем направление к игроку
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            // Перемещаем врага к игроку с определенной скоростью
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Поворот врага в сторону игрока
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}