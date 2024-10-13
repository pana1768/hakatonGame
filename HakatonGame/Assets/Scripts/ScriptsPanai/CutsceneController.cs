using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Не забудьте подключить пространство имен для работы с UI

public class CutsceneController : MonoBehaviour
{
    public float cutsceneDuration = 15f;  // Время до перехода на основной уровень
    public GameObject skipHint;  // Ссылка на объект подсказки
    private float timer;  // Таймер для отслеживания времени катсцены
    private bool isCutsceneSkipped = false;  // Флаг для отслеживания, была ли катсцена пропущена
    public SceneTransition sceneTransition;

    void Start()
    {
        timer = cutsceneDuration;  // Инициализируем таймер
        skipHint.SetActive(false);  // Показываем подсказку
        sceneTransition = FindObjectOfType<SceneTransition>();

    }

    void Update()
    {
        // Проверка нажатия клавиши Enter для пропуска катсцены
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isCutsceneSkipped = true;
            skipHint.SetActive(false);  // Скрываем подсказку
            TransitionToMainLevel();  // Переход на основной уровень сразу
        }

        // Если катсцена не пропущена, уменьшаем таймер
        if (!isCutsceneSkipped)
        {
            timer -= Time.deltaTime;

            // Проверяем, истекло ли время катсцены
            if (timer <= 0)
            {
                TransitionToMainLevel();
            }
            if(timer <= 50)
            {
                skipHint.SetActive(true);
            }
        }
    }

    void TransitionToMainLevel()
    {
        // Загружаем основной уровень

        sceneTransition.LoadScene("FirstLevel");
    }
}
