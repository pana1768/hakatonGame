using UnityEngine;
using UnityEngine.SceneManagement; // ��� �������� ����
using TMPro; // ��� ������ � TextMeshPro
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public GameObject splashScreen; // ������ ��������
    public GameObject spaceBackground; // ������ ���� �������
    public GameObject menu; // ������� ����

    public float splashDuration = 2f; // ����� ����������� ��������

    void Start()
    {
        // ������ ���� � ������
        menu.SetActive(false);
        // ��������� �������� ��� ��������
        StartCoroutine(ShowSplashScreen());
    }

    private IEnumerator ShowSplashScreen()
    {
        // ���������� ��������
        splashScreen.SetActive(true);
        yield return new WaitForSeconds(splashDuration); // ���� 2 �������
        // �������� �������� � ���������� ��� ������� � ����
        splashScreen.SetActive(false);
        spaceBackground.SetActive(true);
        menu.SetActive(true);
    }

    // ����� ��� ������ ����
    public void StartGame()
    {
        // ��������� ����� �������� (�������� �� ���� �������� �����)
        SceneManager.LoadScene("CatScene"); // �������� "CutsceneScene" �� ��� ����� �����
    }

    // ����� ��� ������ �� ����
    public void ExitGame()
    {
        // ��������� ����
        Application.Quit();
    }
}
