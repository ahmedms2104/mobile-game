using UnityEngine;

public class FallingObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("🎯 تم التصادم مع: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("💥 اصطدم بالكائن الساقط!");
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}