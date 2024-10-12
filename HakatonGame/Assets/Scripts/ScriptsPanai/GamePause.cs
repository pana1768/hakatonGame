using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject pauseMenuUI;  // ������ �� ���� �����
    private bool isPaused = false;  // ���� ��� ������������ ��������� �����

    void Update()
    {
        // �������� ������� ������� Esc ��� �����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();  // ���� ���� �� �����, ������������
            }
            else
            {
                Pause();  // ���� ���� �� �� �����, ������ �� �����
            }
        }
    }

    // ����� ��� ������������� ����
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // �������� ����
        Time.timeScale = 1f;  // ��������������� �������� �������
        isPaused = false;  // ��������� ����
    }

    // ����� ��� ����� ����
    void Pause()
    {
        pauseMenuUI.SetActive(true);  // ���������� ����
        Time.timeScale = 0f;  // ������������� ����� � ����
        isPaused = true;  // ��������� ����
    }

    // ����� ��� ������ � ������� ����
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;  // ��������������� ���������� �������� �������
        // �������� ����� ��� ��� �������� � ������� ����, ��������:
        // SceneManager.LoadScene("MainMenu");
    }

    // ����� ��� ������ �� ����
    public void QuitGame()
    {
        Debug.Log("����� �� ����...");
        Application.Quit();  // �������� ����������
    }
}
