using UnityEngine;
using TMPro;

public class PuzzleDisplay : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public TMP_Text puzzleText;
    public string puzzleContent = "What is 2 + 2?";
    private bool isPaused = false;
    public GameObject hintText;
    private bool isPlayerNearTablet = false;  // Флаг рядом ли игрок с планшетом
    private bool isPuzzleActive = false;
    public PuzzleTrigger tableTrigger;  // Ссылка на скрипт триггера

    private void Start()
    {
        puzzleCanvas.SetActive(false);
    }

    private void Update()
    {
        // Если игрок рядом с таблицей и нажал F, показываем загадку
        if (Input.GetKeyDown(KeyCode.F) && tableTrigger.IsPlayerNear())
        {
            ShowPuzzle();
        }

        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            HidePuzzle();
        }
    }

    private void ShowPuzzle()
    {
        puzzleCanvas.SetActive(true);  // Активируем панель с загадкой
        isPuzzleActive = true;
        hintText.SetActive(false);  // Скрываем подсказку "Нажмите F"
        Time.timeScale = 0;  // Ставим игру на паузу
        puzzleText.text = puzzleContent;
        isPaused = true;
        Time.timeScale = 0f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearTablet = true;  // Игрок в зоне планшета
            hintText.SetActive(true);  // Показываем подсказку "Нажмите F"
        }
    }
    private void HidePuzzle()
    {
        puzzleCanvas.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
