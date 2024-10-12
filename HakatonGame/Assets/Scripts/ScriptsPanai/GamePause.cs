using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Ссылка на меню паузы
    private bool isPaused = false;  // Флаг для отслеживания состояния паузы

    void Update()
    {
        // Проверка нажатия клавиши Esc для паузы
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();  // Если игра на паузе, возобновляем
            }
            else
            {
                Pause();  // Если игра не на паузе, ставим на паузу
            }
        }
    }

    // Метод для возобновления игры
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Скрываем меню
        Time.timeScale = 1f;  // Восстанавливаем скорость времени
        isPaused = false;  // Обновляем флаг
    }

    // Метод для паузы игры
    void Pause()
    {
        pauseMenuUI.SetActive(true);  // Показываем меню
        Time.timeScale = 0f;  // Останавливаем время в игре
        isPaused = true;  // Обновляем флаг
    }

    // Метод для выхода в главное меню
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;  // Восстанавливаем нормальную скорость времени
        // Добавьте здесь код для перехода в главное меню, например:
        // SceneManager.LoadScene("MainMenu");
    }

    // Метод для выхода из игры
    public void QuitGame()
    {
        Debug.Log("Выход из игры...");
        Application.Quit();  // Закрытие приложения
    }
}
