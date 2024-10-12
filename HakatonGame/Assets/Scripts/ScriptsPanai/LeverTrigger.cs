using UnityEngine;
using System.Collections;

public class LeverPuzzle : MonoBehaviour
{
    public GameObject plate;  // �����
    public Transform plateUpPosition;  // ������� ������� �����
    public Transform plateStartPosition;  // ��������� ������� �����
    public float moveSpeed = 2f;  // �������� �������� �����
    public float stayUpTime = 3f;  // �����, �� ������� ����� ��������� �������
    private bool playerInRange = false;  // ��������, ��������� �� ����� ����� � �������
    private bool isMoving = false;  // ����� � ��������?


    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !isMoving)
        {
            StartCoroutine(MovePlate());
        }
    }

    IEnumerator MovePlate()
    {
        isMoving = true;

        // ��������� �����
        while (Vector2.Distance(plate.transform.position, plateUpPosition.position) > 0.01f)
        {
            plate.transform.position = Vector2.MoveTowards(plate.transform.position, plateUpPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // ���� 3 ������� �� ������� �������
        yield return new WaitForSeconds(stayUpTime);

        // �������� �����
        while (Vector2.Distance(plate.transform.position, plateStartPosition.position) > 0.01f)
        {
            plate.transform.position = Vector2.MoveTowards(plate.transform.position, plateStartPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }

    // ����������, ��������� �� ����� � ���� ������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
