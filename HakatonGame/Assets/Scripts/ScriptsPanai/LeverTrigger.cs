using UnityEngine;
using System.Collections;

public class LeverPuzzle : MonoBehaviour
{
    public GameObject plate;  // Плита
    public Transform plateUpPosition;  // Верхняя позиция плиты
    public Transform plateStartPosition;  // Стартовая позиция плиты
    public float moveSpeed = 2f;  // Скорость движения плиты
    public float stayUpTime = 3f;  // Время, на которое плита останется наверху
    private bool playerInRange = false;  // Проверка, находится ли игрок рядом с рычагом
    private bool isMoving = false;  // Плита в движении?


    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !isMoving)
        {
            StartCoroutine(MovePlate());
        }
    }

    IEnumerator MovePlate()
    {
        isMoving = true;

        // Поднимаем плиту
        while (Vector2.Distance(plate.transform.position, plateUpPosition.position) > 0.01f)
        {
            plate.transform.position = Vector2.MoveTowards(plate.transform.position, plateUpPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Ждем 3 секунды на верхней позиции
        yield return new WaitForSeconds(stayUpTime);

        // Опускаем плиту
        while (Vector2.Distance(plate.transform.position, plateStartPosition.position) > 0.01f)
        {
            plate.transform.position = Vector2.MoveTowards(plate.transform.position, plateStartPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }

    // Определяем, находится ли игрок в зоне рычага
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
