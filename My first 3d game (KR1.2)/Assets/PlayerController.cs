using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 100f;
    public int experience = 0;
    public int strength = 10;
    public float moveSpeed = 5f;
    public int score = 0; // Очки игрока

    public void AddScore(int points)
    {
        score += points;
    }
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, 0, moveZ));
    }

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(strength);
                }
            }
        }
    }
    
}