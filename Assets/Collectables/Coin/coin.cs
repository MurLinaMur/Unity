using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; // ���������� �����, ����������� ��� �������� �������
    [SerializeField] private GameObject pickupEffect; // ������ �������, ������� ��������������� ��� �������� �������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ���������� �� ������ � �������.
        // ���������, ��� � ������ ������ ���� ��� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // �������� �������, ������� ������������ �������� ������� (��������, ��������� ����)
            CollectCoin(collision.gameObject);
        }
    }

    private void CollectCoin(GameObject player)
    {
        // ����� ����� �������� ������ ���������� ����� ������.
        // ��������, �� ������ ������� ����� �� ������� ������:
        // player.GetComponent<PlayerScore>().AddScore(coinValue);

        // ������� ������ �������� ������� (���� �� ����)
        if (pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
        }

        // ���������� ������ �������
        Destroy(gameObject);
    }
}