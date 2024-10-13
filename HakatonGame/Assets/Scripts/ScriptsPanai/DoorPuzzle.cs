using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, если объект, входящий в триггер, - это игрок
        if (collision.CompareTag("Player"))
        {
            // Переключение на Level2
            SceneManager.LoadScene("lvl1-bunker");
        }
    }
}
