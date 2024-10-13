using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    private bool isPlayerNear = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Проверяем, что объект - игрок
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    public bool IsPlayerNear()
    {
        return isPlayerNear;  // Возвращаем true, если игрок рядом
    }
}
