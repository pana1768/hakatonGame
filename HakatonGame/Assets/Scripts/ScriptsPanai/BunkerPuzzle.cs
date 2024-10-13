using UnityEngine;
using TMPro;

public class PuzzleDoor : MonoBehaviour
{
    public GameObject puzzlePanel;  // ������ UI � ��������
    public TextMeshProUGUI puzzleText;  // ����� ��� �������
    public TMP_InputField answerInput;  // ���� ��� ����� ������
    public GameObject door;  // ������ �����
    public Collider2D doorCollider;  // Collider �����
    public string correctAnswer = "Alice";  // ���������� �����
    public string puzzleQuestion = "Who sent you on the trip?";  // �������
    public GameObject hintText;  // ��������� "������� F"
    private bool isPlayerNearTablet = false;  // ���� ����� �� ����� � ���������
    private bool isPuzzleActive = false;  // ���� ���������� UI � ��������

    void Update()
    {
        // ���������� ������� ��� ������� F
        if (isPlayerNearTablet && Input.GetKeyDown(KeyCode.F) && !isPuzzleActive)
        {
            ShowPuzzle();
        }

        // ��������� ����� ��� ������� Enter
        if (isPuzzleActive && Input.GetKeyDown(KeyCode.Return))
        {
            SubmitAnswer();
        }

        // ��������� ���� ������� ��� ������� Esc
        if (isPuzzleActive && Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePuzzle();  // ��������� ���� � ������� �����
        }
        
    }

    // ����������� UI ������� � ����� ����
    void ShowPuzzle()
    {
        puzzlePanel.SetActive(true);  // ���������� ������ � ��������
        puzzleText.text = puzzleQuestion;  // ���������� ����� �������
        answerInput.text = "";  // ������� ���� ��� ������
        answerInput.ActivateInputField();  // ���������� ����
        isPuzzleActive = true;
        hintText.SetActive(false);  // �������� ��������� "������� F"
        Time.timeScale = 0;  // ������ ���� �� �����
    }

    // �������� ������
    void SubmitAnswer()
    {
        string playerAnswer = answerInput.text;

        if (playerAnswer.ToLower() == correctAnswer.ToLower())
        {
            OpenDoor();  // ��������� �����, ���� ����� ����������
        }
        else
        {
            answerInput.text = "";  // ������� ���� ��� ������ �����
            answerInput.ActivateInputField();  // ����� ���������� ����
        }
    }

    // �������� �����
    void OpenDoor()
    {
        doorCollider.enabled = false;  // ������ ����� ����������
        ClosePuzzle();  // ��������� UI
    }

    // �������� UI � ������ �����
    void ClosePuzzle()
    {
        puzzlePanel.SetActive(false);  // ��������� ������ � ��������
        isPuzzleActive = false;
        Time.timeScale = 1;  // ������� ����� � ����
    }

    // ���� ������ � ���� ��������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearTablet = true;  // ����� � ���� ��������
            hintText.SetActive(true);  // ���������� ��������� "������� F"
        }
    }

    // ����� ������ �� ���� ��������
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearTablet = false;  // ����� ������� ���� ��������
            hintText.SetActive(false);  // �������� ��������� "������� F"
        }
    }
}
