using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;  // ������ �� ������ (Transform ������)
    public float smoothSpeed = 0.125f;  // �������� ����������� �������� ������
    public Vector3 offset;  // �������� ������ ������������ ������

    void LateUpdate()
    {
        // �������� �������� ������� ������ � ������ ��������
        Vector3 desiredPosition = player.position + offset;

        // ������� ����������� ������ � �������� �������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
