using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint;  // ����� ������
    public float fallThreshold = -5f;  // �����, ���� �������� ����� ����� ������������

    void Update()
    {
        // ���������, ���� �� ����� ���� ������
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // ���������� ������ ������� �� ����� ������
        transform.position = spawnPoint.position;
        // ����� �������� �������������� ��������, ����� ��� ����� �������� ��� ��������
        Debug.Log("����� ���������� �� ����� ������");
    }
}
