using UnityEngine;
using TMPro; // ���������� ������������ ���� ��� TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections;

public class TextAnimatorTMP : MonoBehaviour
{
    public string fullText = "day 1.\n\n- - - \n\n\nearth broken, people are dead\n\nmy name is samuel, im a last standing human in universe.\n\nif your heard me, give me a know"; // ������ �����
    public float typingSpeed = 0.1f; // �������� ������
    public KeyCode nextKey = KeyCode.Space; // ������� ��� ��������

    private TMP_Text textComponent; // ������ TextMeshPro
    private bool isTyping = true; // �������� � true, ����� �������� ������ �����������

    void Start()
    {
        textComponent = GetComponent<TMP_Text>(); // �������� ��������� TextMeshPro
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
        isTyping = false; // �������������, ��� �������� ���������
    }

    void Update()
    {
        if (Input.GetKeyDown(nextKey) && !isTyping)
        {
            SceneManager.LoadScene("NextScene"); // ������� ��� ��������� �����
        }
    }
}
