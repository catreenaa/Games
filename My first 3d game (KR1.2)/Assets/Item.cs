using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { HealthPotion, StrengthPotion }
    public ItemType itemType; // Тип предмета
    public float value; // Значение эффекта предмета

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                ApplyEffect(player); // Применить эффект
                Destroy(gameObject); // Удалить предмет после использования
            }
        }
    }

    void ApplyEffect(PlayerController player)
    {
        switch (itemType)
        {
            case ItemType.HealthPotion:
                player.health += value; // Увеличить здоровье
                break;
            case ItemType.StrengthPotion:
                player.strength += (int)value; // Увеличить силу
                break;
        }
    }
}