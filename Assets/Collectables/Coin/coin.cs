using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; // Количество очков, начисляемых при поднятии монетки
    [SerializeField] private GameObject pickupEffect; // Префаб эффекта, который воспроизводится при поднятии монетки

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, столкнулся ли объект с игроком.
        // Убедитесь, что у вашего игрока есть тег "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Вызываем функцию, которая обрабатывает поднятие монетки (например, добавляет очки)
            CollectCoin(collision.gameObject);
        }
    }

    private void CollectCoin(GameObject player)
    {
        // Здесь нужно добавить логику добавления очков игроку.
        // Например, вы можете вызвать метод на скрипте игрока:
        // player.GetComponent<PlayerScore>().AddScore(coinValue);

        // Создаем эффект поднятия монетки (если он есть)
        if (pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
        }

        // Уничтожаем объект монетки
        Destroy(gameObject);
    }
}