using UnityEngine;
using TMPro;

public class PuzzleDisplay : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public TMP_Text puzzleText;
    public string puzzleContent = "What is 2 + 2?";
    private bool isPaused = false;
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
        puzzleCanvas.SetActive(true);
        puzzleText.text = puzzleContent;
        isPaused = true;
        Time.timeScale = 0f;
    }

    private void HidePuzzle()
    {
        puzzleCanvas.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
