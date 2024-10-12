using UnityEngine;

public class SignInteraction : MonoBehaviour
{
    public GameObject signCanvas;  // UI Canvas � ������� ��������
    private bool isPlayerNearby = false;  // ���� ��� ������������, ����� �� �����
    private bool isSignVisible = false;   // ���� ��� ����������� ��������

    void Update()
    {
        // ���������, ����� �� ����� � ����� �� �� F
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            ShowSign();  // �������� ��������
            Debug.Log("������ ������� F, ���������� ��������");
        }

        // �������� �������� �� ������� �� Esc
        if (isSignVisible && Input.GetKeyDown(KeyCode.Escape))
        {
            HideSign();  // ������ ��������
            Debug.Log("������ ������� Esc, �������� ��������");
        }
    }

    // �������� ��������
    void ShowSign()
    {
        signCanvas.SetActive(true);  // �������� Canvas � �������
        isSignVisible = true;        // ��������� ����
        Time.timeScale = 0f;         // ������������� ����, ���� �����
        Debug.Log("�������� ��������");
    }

    // ������ ��������
    void HideSign()
    {
        signCanvas.SetActive(false);  // ��������� Canvas
        isSignVisible = false;        // ��������� ����
        Time.timeScale = 1f;          // ���������� ���������� �������� ����
        Debug.Log("�������� ������");
    }

    // ������ � ������� ��������
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // ���������, ��� ����� �����
        {
            isPlayerNearby = true;
            Debug.Log("����� ������� � ��������");
        }
    }

    // ������� �� �������� ��������
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // ���������, ��� ����� �����
        {
            isPlayerNearby = false;
            Debug.Log("����� ������ �� ��������");
        }
    }
}
