using UnityEngine;
using TMPro; // Подключаем пространство имен для TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections;

public class TextAnimatorTMP : MonoBehaviour
{
    public string fullText = "18.03.2135 \n\nThere was a successful launch of board 117x53 to search for an Earth-type planet. \nAll sensors and systems are working properly. \nFurther control is transferred to the AI system"; // Полный текст
    public float typingSpeed = 0.1f; // Скорость печати
    public string fullText2 = "18.05.2136 \n\nCommunication with the control center of board 117x53 was lost...";
    public string fullText3 = "25.08.2344 [117x53 EXP-0 1175493.log] \n\nA planet suitable for the search conditions was found and the protocol for return to Earth was started.";
    public string fullText4 = "25.08.2544 [117x53 EXP-0 1265432.log] \n\nLanding on planet Earth:\nOxygen level - 0%.\nLife level - 0% \nRadiation level - 70%. \nEXP-0 protocol initiated.";
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
        yield return new WaitForSeconds(1f);
        textComponent.text = "";
        foreach (char letter in fullText2.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(1f);
        textComponent.text = "";
        foreach (char letter in fullText3.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(1f);
        textComponent.text = "";
        foreach (char letter in fullText4.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false; // Устанавливаем, что анимация завершена
    }
}
