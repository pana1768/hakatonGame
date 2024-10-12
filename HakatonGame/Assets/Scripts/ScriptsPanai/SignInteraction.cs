using UnityEngine;

public class SignInteraction : MonoBehaviour
{
    public GameObject signCanvas;  // UI Canvas с текстом таблички
    private bool isPlayerNearby = false;  // Флаг для отслеживания, рядом ли игрок
    private bool isSignVisible = false;   // Флаг для отображения таблички

    void Update()
    {
        // Проверяем, рядом ли игрок и нажал ли он F
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            ShowSign();  // Показать табличку
            Debug.Log("Нажата клавиша F, показываем табличку");
        }

        // Закрытие таблички по нажатию на Esc
        if (isSignVisible && Input.GetKeyDown(KeyCode.Escape))
        {
            HideSign();  // Скрыть табличку
            Debug.Log("Нажата клавиша Esc, скрываем табличку");
        }
    }

    // Показать табличку
    void ShowSign()
    {
        signCanvas.SetActive(true);  // Включаем Canvas с текстом
        isSignVisible = true;        // Обновляем флаг
        Time.timeScale = 0f;         // Останавливаем игру, если нужно
        Debug.Log("Табличка показана");
    }

    // Скрыть табличку
    void HideSign()
    {
        signCanvas.SetActive(false);  // Отключаем Canvas
        isSignVisible = false;        // Обновляем флаг
        Time.timeScale = 1f;          // Возвращаем нормальную скорость игры
        Debug.Log("Табличка скрыта");
    }

    // Входим в триггер таблички
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Проверяем, что вошел игрок
        {
            isPlayerNearby = true;
            Debug.Log("Игрок подошел к табличке");
        }
    }

    // Выходим из триггера таблички
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Проверяем, что вышел игрок
        {
            isPlayerNearby = false;
            Debug.Log("Игрок отошел от таблички");
        }
    }
}
