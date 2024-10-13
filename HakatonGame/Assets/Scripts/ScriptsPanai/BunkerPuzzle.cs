using UnityEngine;
using TMPro;

public class PuzzleDoor : MonoBehaviour
{
    public GameObject puzzlePanel;  // Панель UI с загадкой
    public TextMeshProUGUI puzzleText;  // Текст для загадки
    public TMP_InputField answerInput;  // Поле для ввода ответа
    public GameObject door;  // Объект двери
    public Collider2D doorCollider;  // Collider двери
    public string correctAnswer = "Alice";  // Правильный ответ
    public string puzzleQuestion = "Who sent you on the trip?";  // Загадка
    public GameObject hintText;  // Подсказка "Нажмите F"
    private bool isPlayerNearTablet = false;  // Флаг рядом ли игрок с планшетом
    private bool isPuzzleActive = false;  // Флаг активности UI с загадкой

    void Update()
    {
        // Показываем загадку при нажатии F
        if (isPlayerNearTablet && Input.GetKeyDown(KeyCode.F) && !isPuzzleActive)
        {
            ShowPuzzle();
        }

        // Проверяем ответ при нажатии Enter
        if (isPuzzleActive && Input.GetKeyDown(KeyCode.Return))
        {
            SubmitAnswer();
        }

        // Закрываем окно загадки при нажатии Esc
        if (isPuzzleActive && Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePuzzle();  // Закрываем окно и снимаем паузу
        }
        
    }

    // Отображение UI загадки и пауза игры
    void ShowPuzzle()
    {
        puzzlePanel.SetActive(true);  // Активируем панель с загадкой
        puzzleText.text = puzzleQuestion;  // Отображаем текст загадки
        answerInput.text = "";  // Очищаем поле для ответа
        answerInput.ActivateInputField();  // Активируем ввод
        isPuzzleActive = true;
        hintText.SetActive(false);  // Скрываем подсказку "Нажмите F"
        Time.timeScale = 0;  // Ставим игру на паузу
    }

    // Проверка ответа
    void SubmitAnswer()
    {
        string playerAnswer = answerInput.text;

        if (playerAnswer.ToLower() == correctAnswer.ToLower())
        {
            OpenDoor();  // Открываем дверь, если ответ правильный
        }
        else
        {
            answerInput.text = "";  // Очищаем поле для нового ввода
            answerInput.ActivateInputField();  // Снова активируем ввод
        }
    }

    // Открытие двери
    void OpenDoor()
    {
        doorCollider.enabled = false;  // Делаем дверь проходимой
        ClosePuzzle();  // Закрываем UI
    }

    // Закрытие UI и снятие паузы
    void ClosePuzzle()
    {
        puzzlePanel.SetActive(false);  // Отключаем панель с загадкой
        isPuzzleActive = false;
        Time.timeScale = 1;  // Снимаем паузу с игры
    }

    // Вход игрока в зону планшета
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearTablet = true;  // Игрок в зоне планшета
            hintText.SetActive(true);  // Показываем подсказку "Нажмите F"
        }
    }

    // Выход игрока из зоны планшета
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearTablet = false;  // Игрок покинул зону планшета
            hintText.SetActive(false);  // Скрываем подсказку "Нажмите F"
        }
    }
}
