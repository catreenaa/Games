using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { HealthPotion, StrengthPotion }
    public ItemType itemType; // ��� ��������
    public float value; // �������� ������� ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                ApplyEffect(player); // ��������� ������
                Destroy(gameObject); // ������� ������� ����� �������������
            }
        }
    }

    void ApplyEffect(PlayerController player)
    {
        switch (itemType)
        {
            case ItemType.HealthPotion:
                player.health += value; // ��������� ��������
                break;
            case ItemType.StrengthPotion:
                player.strength += (int)value; // ��������� ����
                break;
        }
    }
}