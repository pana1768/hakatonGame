using UnityEngine;

public class PanelTrigger : MonoBehaviour
{
    private bool isNearPanel = false;

    // �����, ���������� ��� ����� � ���������� ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���������, �������� �� ������ �������
        {
            isNearPanel = true; // ����� ����� � �������
        }
    }

    // �����, ���������� ��� ������ �� ���������� ����
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPanel = false; // ����� ���� �� ������
        }
    }

    public bool IsNearPanel()
    {
        return isNearPanel; // ����������, ��������� �� ����� ����� � �������
    }
}
