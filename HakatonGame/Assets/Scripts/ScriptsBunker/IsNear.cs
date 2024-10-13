using UnityEngine;

public class PanelTrigger : MonoBehaviour
{
    private bool isNearPanel = false;

    // Метод, вызываемый при входе в триггерную зону
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, является ли объект игроком
        {
            isNearPanel = true; // Игрок рядом с панелью
        }
    }

    // Метод, вызываемый при выходе из триггерной зоны
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPanel = false; // Игрок ушел от панели
        }
    }

    public bool IsNearPanel()
    {
        return isNearPanel; // Возвращаем, находится ли игрок рядом с панелью
    }
}
