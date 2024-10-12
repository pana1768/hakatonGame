using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint;  // Точка спавна
    public float fallThreshold = -5f;  // Порог, ниже которого игрок будет респавниться

    void Update()
    {
        // Проверяем, упал ли игрок ниже порога
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Перемещаем игрока обратно на точку спавна
        transform.position = spawnPoint.position;
        // Можно добавить дополнительные действия, такие как сброс здоровья или анимация
        Debug.Log("Игрок возродился на точке спавна");
    }
}
