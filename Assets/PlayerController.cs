using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  // ÓÑÚÉ ÕÚæÏ ÇááÇÚÈ
    public float jumpForce = 0f;  // ÞæÉ ÇáÞÝÒ
    public Rigidbody2D rb;
    private float screenWidth;
    private float fixedY;  // ÞíãÉ Y ÇáËÇÈÊÉ

    void Start()
    {
        // ÍÓÇÈ ÚÑÖ ÇáÔÇÔÉ ÈäÇÁð Úáì ÍÌã ÇáßÇãíÑÇ
        screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        Application.targetFrameRate = 60;  // ÊÍÏíÏ ãÚÏá ÇáÅØÇÑÇÊ ááÌæÇá

        // ÍÝÙ ÞíãÉ Y ÇáÍÇáíÉ áÊÈÞì ËÇÈÊÉ
        fixedY = transform.position.y;
    }

    void Update()
    {
        // ÅÈÞÇÁ Y ËÇÈÊðÇ æÚÏã ÊÛííÑå
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);

        // ÇáÞÝÒ Åáì ÇáÌåÉ ÇáÃÎÑì ÚäÏ ÇáÖÛØ Úáì ÇáÔÇÔÉ
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (transform.position.x > 0)
                transform.position = new Vector3(-screenWidth, fixedY, transform.position.z);
            else
                transform.position = new Vector3(screenWidth, fixedY, transform.position.z);
        }
    }
}
