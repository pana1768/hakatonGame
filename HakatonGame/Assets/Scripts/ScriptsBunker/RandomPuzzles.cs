using UnityEngine;
using TMPro;

public class RandomPuzzles : MonoBehaviour
{
    public GameObject puzzlePanel;  // ������ UI � ��������
    public TextMeshProUGUI puzzleText;  // ����� ��� �������
    public TMP_InputField answerInput;  // ���� ��� ����� ������
    public GameObject door;  // ������ �����
    public Collider2D doorCollider;  // Collider �����
    public GameObject hintText;  // ��������� "������� F"

    private bool isPlayerNearTablet = false;  // ���� ����� �� ����� � ���������
    private bool isPuzzleActive = false;  // ���� ���������� UI � ��������

    private string[] puzzles = new string[]
    {
        "You see me at night, but can't touch me at all. I sparkle so bright, then vanish by fall. What am I?",
        "I'm big but hard to see, Always orbiting the sun, that's me. What am I?",
        "WI'm a nightly friend, round and bright, Reflecting sunlight with soft, pale light. Who am I?",
        "I'm fiery and bright, a ball of heat, Shining my rays down on your street. What am I?",
        "With a tail so long, I light up the sky, A fleeting glance before I say goodbye. What am I?"
    };  // ������ �������

    private string[] correctAnswers = new string[]
    {
        "Stars",
        "Planet",
        "Moon",
        "Sun",
        "Comet"
    };  // ������ ���������� �������

    private int currentPuzzleIndex;  // ������ ������� �������

    void Start()
    {
        SelectRandomPuzzle();  // �������� ��������� ������� ��� ������
    }

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
        puzzleText.text = puzzles[currentPuzzleIndex];  // ���������� ��������� �������
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

        if (playerAnswer.ToLower() == correctAnswers[currentPuzzleIndex].ToLower())
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

    // ����� ��������� �������
    void SelectRandomPuzzle()
    {
        currentPuzzleIndex = Random.Range(0, puzzles.Length);  // �������� ��������� ������ �������
    }
}
