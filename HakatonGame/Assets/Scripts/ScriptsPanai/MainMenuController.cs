using UnityEngine;
using UnityEngine.SceneManagement; // Для загрузки сцен
using TMPro; // Для работы с TextMeshPro
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public GameObject splashScreen; // Объект заставки
    public GameObject spaceBackground; // Объект фона космоса
    public GameObject menu; // Главное меню

    public float splashDuration = 2f; // Время отображения заставки

    void Start()
    {
        // Скрыть меню в начале
        menu.SetActive(false);
        // Запускаем корутину для заставки
        StartCoroutine(ShowSplashScreen());
    }

    private IEnumerator ShowSplashScreen()
    {
        // Отображаем заставку
        splashScreen.SetActive(true);
        yield return new WaitForSeconds(splashDuration); // Ждем 2 секунды
        // Скрываем заставку и показываем фон космоса и меню
        splashScreen.SetActive(false);
        spaceBackground.SetActive(true);
        menu.SetActive(true);
    }

    // Метод для начала игры
    public void StartGame()
    {
        // Загрузить сцену катсцены (замените на ваше название сцены)
        SceneManager.LoadScene("CatScene"); // Замените "CutsceneScene" на имя вашей сцены
    }

    // Метод для выхода из игры
    public void ExitGame()
    {
        // Закрываем игру
        Application.Quit();
    }
}
