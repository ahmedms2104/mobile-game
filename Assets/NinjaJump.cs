using UnityEngine;

public class NinjaJump : MonoBehaviour
{
    public float jumpForce = 5f; // ��� ����� �������
    public Transform mainCamera; // �������� ������� ������
    private Rigidbody2D rb;
    private int direction = 1; // 1 = ���� -1 = ����
    private bool isTouchingWall = false; // ������ �� ��� ������
    private float fixedY; // ���� Y �������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedY = transform.position.y; // ����� ���� Y ���� �������
    }

    void Update()
    {
        // ����� ������ ��� ������ ���� ������
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);

        // ����� ��� ����� ������ ��� ��� ������ ������ ��� ������
        if (isTouchingWall && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Jump();
        }

        // ����� �������� ������ ������ ����� ������ ������ ������
        if (mainCamera != null && transform.position.y > mainCamera.position.y)
        {
            mainCamera.position = Vector3.Lerp(mainCamera.position, new Vector3(mainCamera.position.x, transform.position.y, mainCamera.position.z), Time.deltaTime * 5f);
        }
    }

    void Jump()
    {
        direction *= -1; // ����� ������� ��� �������
        rb.velocity = new Vector2(direction * jumpForce, 0); // ��� ���� ��� ���� ����� �� Y
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
        }
    }
}
