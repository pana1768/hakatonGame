using UnityEngine;
using TMPro;

public class CezarDisplay : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public TMP_Text puzzleText;
    public string puzzleContent = "\tI shift letters and change their place,\r\n\t" +
        "Moving forward in a steady pace.\r\n\t" +
        "Three steps ahead, that's how it goes,\r\n\t" +
        "What number am I, do you suppose?";
    private bool isPaused = false;
    public GameObject hintText;
    private bool isPlayerNearTablet = false;  // ���� ����� �� ����� � ���������
    private bool isPuzzleActive = false;
    public PuzzleTrigger tableTrigger;  // ������ �� ������ ��������

    private void Start()
    {
        puzzleCanvas.SetActive(false);
    }

    private void Update()
    {
        // ���� ����� ����� � �������� � ����� F, ���������� �������
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
        puzzleCanvas.SetActive(true);  // ���������� ������ � ��������
        isPuzzleActive = true;
        hintText.SetActive(false);  // �������� ��������� "������� F"
        Time.timeScale = 0;  // ������ ���� �� �����
        puzzleText.text = puzzleContent;
        isPaused = true;
        Time.timeScale = 0f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearTablet = true;  // ����� � ���� ��������
            hintText.SetActive(true);  // ���������� ��������� "������� F"
        }
    }
    private void HidePuzzle()
    {
        puzzleCanvas.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
