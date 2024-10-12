using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;  // Ссылка на игрока (Transform игрока)
    public float smoothSpeed = 0.125f;  // Скорость сглаживания движения камеры
    public Vector3 offset;  // Смещение камеры относительно игрока

    void LateUpdate()
    {
        // Получаем желаемую позицию камеры с учётом смещения
        Vector3 desiredPosition = player.position + offset;

        // Плавное перемещение камеры к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
