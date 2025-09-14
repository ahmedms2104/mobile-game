using UnityEngine;

public class NinjaJump : MonoBehaviour
{
    public float jumpForce = 5f; // ﬁÊ… «·ﬁ›“ «·√›ﬁÌ…
    public Transform mainCamera; // «·ﬂ«„Ì—« ·„ «»⁄… «··«⁄»
    private Rigidbody2D rb;
    private int direction = 1; // 1 = Ì„Ì‰° -1 = Ì”«—
    private bool isTouchingWall = false; // «· Õﬁﬁ „‰ ·„” «·Ãœ«—
    private float fixedY; // ﬁÌ„… Y «·À«» …

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedY = transform.position.y; //  Œ“Ì‰ ﬁÌ„… Y ·⁄œ„  €ÌÌ—Â«
    }

    void Update()
    {
        //  À»Ì  «··«⁄» ⁄·Ï «— ›«⁄ „⁄Ì‰ œ«∆„«
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);

        // «·ﬁ›“ ≈·Ï «·ÃÂ… «·√Œ—Ï ⁄‰œ ·„” «·Ãœ«— Ê«·÷€ÿ ⁄·Ï «·‘«‘…
        if (isTouchingWall && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Jump();
        }

        //  Õ—Ìﬂ «·ﬂ«„Ì—« ··√⁄·Ï »”·«”… ⁄‰œ„« Ì Ã«Ê“ «··«⁄» „Êﬁ⁄Â«
        if (mainCamera != null && transform.position.y > mainCamera.position.y)
        {
            mainCamera.position = Vector3.Lerp(mainCamera.position, new Vector3(mainCamera.position.x, transform.position.y, mainCamera.position.z), Time.deltaTime * 5f);
        }
    }

    void Jump()
    {
        direction *= -1; //  €ÌÌ— «·« Ã«Â »Ì‰ «·Ãœ—«‰
        rb.velocity = new Vector2(direction * jumpForce, 0); // ﬁ›“ √›ﬁÌ ›ﬁÿ »œÊ‰  €ÌÌ— ›Ì Y
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
