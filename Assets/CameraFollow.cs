using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // ������ ���� ����� ��������
    public float smoothSpeed = 0.2f;  // ���� ������ ������ ��������
    public Vector3 offset;  // ������� ��� �������� �������

    void Start()
    {
        offset = transform.position - player.position;  // ��� ������� ��� �������� �������
    }

    void LateUpdate()
    {
        // ������ ������ ��������
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}

