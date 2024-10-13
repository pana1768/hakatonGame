using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // �� �������� ���������� ������������ ���� ��� ������ � UI

public class CutsceneController : MonoBehaviour
{
    public float cutsceneDuration = 15f;  // ����� �� �������� �� �������� �������
    public GameObject skipHint;  // ������ �� ������ ���������
    private float timer;  // ������ ��� ������������ ������� ��������
    private bool isCutsceneSkipped = false;  // ���� ��� ������������, ���� �� �������� ���������
    public SceneTransition sceneTransition;

    void Start()
    {
        timer = cutsceneDuration;  // �������������� ������
        skipHint.SetActive(false);  // ���������� ���������
        sceneTransition = FindObjectOfType<SceneTransition>();

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
            if(timer <= 50)
            {
                skipHint.SetActive(true);
            }
        }
    }

    void TransitionToMainLevel()
    {
        // ��������� �������� �������

        sceneTransition.LoadScene("FirstLevel");
    }
}
