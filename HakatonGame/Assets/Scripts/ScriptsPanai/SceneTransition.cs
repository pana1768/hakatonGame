using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // ���������� ������������ ���� ��� ������ � UI
using System.Collections; // ��� �������

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // ������ �� ����������� ����������
    public float fadeDuration = 1f; // ������������ ����������

    private void Start()
    {
        StartCoroutine(FadeIn()); // �������� � ���������� ������
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName)); // ��������� �������� ��� ��������
    }

    private IEnumerator FadeIn()
    {
        float alpha = 1f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null; // ���� �� ���������� �����
        }
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float alpha = 0;
        fadeImage.gameObject.SetActive(true); // ���������� ����������� ����������
        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null; // ���� �� ���������� �����
        }
        SceneManager.LoadScene(sceneName); // ��������� ����� �����
    }
}
