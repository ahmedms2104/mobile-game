using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;  // «·„‰’… «· Ì ”Ì „ ≈‰‘«ƒÂ«
    private float spawnY = 5f;  // «— ›«⁄ ≈‰‘«¡ «·„‰’« 
    private float screenWidth;  // ⁄—÷ «·‘«‘…
    private int platformCount = 10;  // ⁄œœ «·„‰’« 

    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        for (int i = 0; i < platformCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-screenWidth, screenWidth), spawnY, 0);

            //  Õﬁﬁ „‰ √‰ spawnPosition  Õ ÊÌ ⁄·Ï ﬁÌ„ „⁄ﬁÊ·…
            if (spawnPosition.y < -5 || spawnPosition.y > 10)
            {
                Debug.LogWarning("«·ﬁÌ„… spawnPosition €Ì— ’ÕÌÕ…: " + spawnPosition);
            }

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);  // ≈‰‘«¡ «·„‰’…
            spawnY += Random.Range(1.5f, 3f);  // “Ì«œ… Y ··„—… «·ﬁ«œ„…
        }
    }
}
