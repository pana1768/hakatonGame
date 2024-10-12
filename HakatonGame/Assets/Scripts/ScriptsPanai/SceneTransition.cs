using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Подключите пространство имен для работы с UI
using System.Collections; // Для корутин

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // Ссылка на изображение затемнения
    public float fadeDuration = 1f; // Длительность затемнения

    private void Start()
    {
        StartCoroutine(FadeIn()); // Начинаем с затемнения экрана
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName)); // Запускаем корутину для перехода
    }

    private IEnumerator FadeIn()
    {
        float alpha = 1f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null; // Ждем до следующего кадра
        }
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float alpha = 0;
        fadeImage.gameObject.SetActive(true); // Активируем изображение затемнения
        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null; // Ждем до следующего кадра
        }
        SceneManager.LoadScene(sceneName); // Загружаем новую сцену
    }
}
