using UnityEngine;
using TMPro; // Подключаем пространство имен для TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections;

public class TextAnimatorTMP : MonoBehaviour
{
    public string fullText = "day 1.\n\n- - - \n\n\nearth broken, people are dead\n\nmy name is samuel, im a last standing human in universe.\n\nif your heard me, give me a know"; // Полный текст
    public float typingSpeed = 0.1f; // Скорость печати
    public KeyCode nextKey = KeyCode.Space; // Клавиша для перехода

    private TMP_Text textComponent; // Объект TextMeshPro
    private bool isTyping = true; // Начинаем с true, чтобы анимация текста запустилась

    void Start()
    {
        textComponent = GetComponent<TMP_Text>(); // Получаем компонент TextMeshPro
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";
        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false; // Устанавливаем, что анимация завершена
    }

    void Update()
    {
        if (Input.GetKeyDown(nextKey) && !isTyping)
        {
            SceneManager.LoadScene("NextScene"); // Укажите имя следующей сцены
        }
    }
}
