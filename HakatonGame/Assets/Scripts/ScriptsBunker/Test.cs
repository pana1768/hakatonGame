using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimonSaysPuzzle : MonoBehaviour
{
    public Button[] buttons; // массив кнопок
    private List<int> sequence = new List<int>(); // список для хранения последовательности
    private List<int> playerInput = new List<int>(); // ввод игрока
    private int level = 1; // текущий уровень (сколько кнопок в последовательности)
    private bool playerTurn = false; // флаг, показывающий, ход ли игрока

    public GameObject puzzlePanel; // панель с кнопками
    public PanelTrigger panelTrigger; // ссылка на триггер панели

    void Start()
    {
        puzzlePanel.SetActive(false); // скрываем панель при старте
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && panelTrigger.IsNearPanel()) // проверяем нажатие F и близость к панели
        {
            StartCoroutine(StartPuzzle());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && puzzlePanel.activeSelf) // Выход из головоломки по Esc
        {
            ClosePuzzle();
        }
    }

    // Запуск головоломки
    IEnumerator StartPuzzle()
    {
        Time.timeScale = 0f; // Ставим игру на паузу
        puzzlePanel.SetActive(true); // показываем панель с кнопками
        yield return new WaitForSecondsRealtime(0.5f); // Ожидаем, чтобы показать последовательность

        // Очищаем последовательности для нового раунда
        sequence.Clear();
        playerInput.Clear();

        // Генерируем новую последовательность
        for (int i = 0; i < level; i++)
        {
            int randomButtonIndex = Random.Range(0, buttons.Length);
            sequence.Add(randomButtonIndex);
            yield return StartCoroutine(ShowButtonSequence(randomButtonIndex));
            yield return new WaitForSecondsRealtime(0.5f); // Ожидаем между показами кнопок
        }

        playerTurn = true; // передаем ход игроку
    }

    // Показ последовательности нажатия
    IEnumerator ShowButtonSequence(int buttonIndex)
    {
        Button button = buttons[buttonIndex];
        Color originalColor = button.image.color;

        button.image.color = Color.yellow; // зажигаем кнопку
        yield return new WaitForSecondsRealtime(1f); // Ожидание в реальном времени, чтобы игра оставалась на паузе
        button.image.color = originalColor; // возвращаем исходный цвет
    }

    // Метод, который будет привязан к кнопкам
    public void OnButtonPress(int buttonIndex)
    {
        if (!playerTurn) return; // если не ход игрока, игнорируем нажатие

        playerInput.Add(buttonIndex);

        // Проверяем ввод игрока
        for (int i = 0; i < playerInput.Count; i++)
        {
            if (playerInput[i] != sequence[i])
            {
                level = 1;
                Debug.Log("Неправильная последовательность!");
                ClosePuzzle(); // Закрыть панель
                return;
            }
        }

        // Если ввод верен и вся последовательность введена
        if (playerInput.Count == sequence.Count)
        {
            Debug.Log("Правильная последовательность!");
            level++; // увеличиваем уровень
            StartCoroutine(StartPuzzle()); // начинаем новый уровень
        }
    }

    // Закрытие головоломки
    void ClosePuzzle()
    {
        Time.timeScale = 1f; // Возвращаем нормальное время
        puzzlePanel.SetActive(false); // Скрываем панель
        playerTurn = false; // Сбрасываем ход игрока
    }
}
