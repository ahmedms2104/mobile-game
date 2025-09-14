using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // «··«⁄» «·–Ì   »⁄Â «·ﬂ«„Ì—«
    public float smoothSpeed = 0.2f;  // ”—⁄… «·Õ—ﬂ… «·”·”… ··ﬂ«„Ì—«
    public Vector3 offset;  // «·„”«›… »Ì‰ «·ﬂ«„Ì—« Ê«··«⁄»

    void Start()
    {
        offset = transform.position - player.position;  // Õ›Ÿ «·„”«›… »Ì‰ «·ﬂ«„Ì—« Ê«··«⁄»
    }

    void LateUpdate()
    {
        // «·Õ—ﬂ… «·”·”… ··ﬂ«„Ì—«
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}

