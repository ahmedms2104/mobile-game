using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  // ���� ���� ������
    public float jumpForce = 0f;  // ��� �����
    public Rigidbody2D rb;
    private float screenWidth;
    private float fixedY;  // ���� Y �������

    void Start()
    {
        // ���� ��� ������ ����� ��� ��� ��������
        screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        Application.targetFrameRate = 60;  // ����� ���� �������� ������

        // ��� ���� Y ������� ����� �����
        fixedY = transform.position.y;
    }

    void Update()
    {
        // ����� Y ������ ���� ������
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);

        // ����� ��� ����� ������ ��� ����� ��� ������
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (transform.position.x > 0)
                transform.position = new Vector3(-screenWidth, fixedY, transform.position.z);
            else
                transform.position = new Vector3(screenWidth, fixedY, transform.position.z);
        }
    }
}
