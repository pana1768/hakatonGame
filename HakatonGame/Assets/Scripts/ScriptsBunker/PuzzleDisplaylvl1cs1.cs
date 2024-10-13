using UnityEngine;
using TMPro;

public class FirstTabletDisplay : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public TMP_Text puzzleText;
    public string puzzleContent = "The Big Dipper remained unchanged, with 7 stars bright and clearly visible.\r\n\t\t" +
        "Orion's Belt shone especially bright today, with all 3 stars forming it clearly visible.\r\n\t\t" +
        "In the Little Bear, 6 stars are unchanged, and Polaris also requires special attention.\r\n\t\t" +
        "In the constellation of Cassiopeia 4 stars are clearly visible, Cephus is worth watching, it has been fading lately.";
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
