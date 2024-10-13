using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ���� ������, �������� � �������, - ��� �����
        if (collision.CompareTag("Player"))
        {
            // ������������ �� Level2
            SceneManager.LoadScene("lvl1-bunker");
        }
    }
}
