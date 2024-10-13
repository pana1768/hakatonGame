using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimonSaysPuzzle : MonoBehaviour
{
    public Button[] buttons; // ������ ������
    private List<int> sequence = new List<int>(); // ������ ��� �������� ������������������
    private List<int> playerInput = new List<int>(); // ���� ������
    private int level = 1; // ������� ������� (������� ������ � ������������������)
    private bool playerTurn = false; // ����, ������������, ��� �� ������

    public GameObject puzzlePanel; // ������ � ��������
    public PanelTrigger panelTrigger; // ������ �� ������� ������

    void Start()
    {
        puzzlePanel.SetActive(false); // �������� ������ ��� ������
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && panelTrigger.IsNearPanel()) // ��������� ������� F � �������� � ������
        {
            StartCoroutine(StartPuzzle());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && puzzlePanel.activeSelf) // ����� �� ����������� �� Esc
        {
            ClosePuzzle();
        }
    }

    // ������ �����������
    IEnumerator StartPuzzle()
    {
        Time.timeScale = 0f; // ������ ���� �� �����
        puzzlePanel.SetActive(true); // ���������� ������ � ��������
        yield return new WaitForSecondsRealtime(0.5f); // �������, ����� �������� ������������������

        // ������� ������������������ ��� ������ ������
        sequence.Clear();
        playerInput.Clear();

        // ���������� ����� ������������������
        for (int i = 0; i < level; i++)
        {
            int randomButtonIndex = Random.Range(0, buttons.Length);
            sequence.Add(randomButtonIndex);
            yield return StartCoroutine(ShowButtonSequence(randomButtonIndex));
            yield return new WaitForSecondsRealtime(0.5f); // ������� ����� �������� ������
        }

        playerTurn = true; // �������� ��� ������
    }

    // ����� ������������������ �������
    IEnumerator ShowButtonSequence(int buttonIndex)
    {
        Button button = buttons[buttonIndex];
        Color originalColor = button.image.color;

        button.image.color = Color.yellow; // �������� ������
        yield return new WaitForSecondsRealtime(1f); // �������� � �������� �������, ����� ���� ���������� �� �����
        button.image.color = originalColor; // ���������� �������� ����
    }

    // �����, ������� ����� �������� � �������
    public void OnButtonPress(int buttonIndex)
    {
        if (!playerTurn) return; // ���� �� ��� ������, ���������� �������

        playerInput.Add(buttonIndex);

        // ��������� ���� ������
        for (int i = 0; i < playerInput.Count; i++)
        {
            if (playerInput[i] != sequence[i])
            {
                level = 1;
                Debug.Log("������������ ������������������!");
                ClosePuzzle(); // ������� ������
                return;
            }
        }

        // ���� ���� ����� � ��� ������������������ �������
        if (playerInput.Count == sequence.Count)
        {
            Debug.Log("���������� ������������������!");
            level++; // ����������� �������
            StartCoroutine(StartPuzzle()); // �������� ����� �������
        }
    }

    // �������� �����������
    void ClosePuzzle()
    {
        Time.timeScale = 1f; // ���������� ���������� �����
        puzzlePanel.SetActive(false); // �������� ������
        playerTurn = false; // ���������� ��� ������
    }
}
