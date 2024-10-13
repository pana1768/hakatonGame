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
