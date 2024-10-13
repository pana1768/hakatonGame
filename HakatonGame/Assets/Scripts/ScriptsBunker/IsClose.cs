using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    private bool isPlayerNear = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // ���������, ��� ������ - �����
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    public bool IsPlayerNear()
    {
        return isPlayerNear;  // ���������� true, ���� ����� �����
    }
}
