using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // �� �������� ���������� ������������ ���� ��� ������ � UI

public class CutsceneController : MonoBehaviour
{
    public float cutsceneDuration = 15f;  // ����� �� �������� �� �������� �������
    public GameObject skipHint;  // ������ �� ������ ���������
    private float timer;  // ������ ��� ������������ ������� ��������
    private bool isCutsceneSkipped = false;  // ���� ��� ������������, ���� �� �������� ���������

    void Start()
    {
        timer = cutsceneDuration;  // �������������� ������
        skipHint.SetActive(false);  // ���������� ���������
    }

    void Update()
    {
        // �������� ������� ������� Enter ��� �������� ��������
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isCutsceneSkipped = true;
            skipHint.SetActive(false);  // �������� ���������
            TransitionToMainLevel();  // ������� �� �������� ������� �����
        }

        // ���� �������� �� ���������, ��������� ������
        if (!isCutsceneSkipped)
        {
            timer -= Time.deltaTime;

            // ���������, ������� �� ����� ��������
            if (timer <= 0)
            {
                TransitionToMainLevel();
            }
            if(timer <= 15)
            {
                skipHint.SetActive(true);
            }
        }
    }

    void TransitionToMainLevel()
    {
        // ��������� �������� �������
        SceneManager.LoadScene("MainScene");
    }
}
