using UnityEngine;

public class FallingObjectsSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // «·ﬂ«∆‰ «·–Ì ”Ì”ﬁÿ
    public Transform spawnArea; // «·„‰ÿﬁ… «· Ì  ”ﬁÿ „‰Â« «·ﬂ«∆‰« 

    public float initialFallSpeed = 2f; // ”—⁄… «·”ﬁÊÿ «·√Ê·Ì…
    public float accelerationRate = 0.5f; // „⁄œ·  ”«—⁄ «·”ﬁÊÿ
    public float spawnInterval = 1f; // «·„œ… »Ì‰ ﬂ· ≈”ﬁ«ÿ

    private float nextSpawnTime;
    private float currentFallSpeed;

    void Start()
    {
        currentFallSpeed = initialFallSpeed;
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }

        // “Ì«œ… ”—⁄… «·”ﬁÊÿ „⁄ «·Êﬁ 
        currentFallSpeed += accelerationRate * Time.deltaTime;
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
            spawnArea.position.y,
            Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
        );

        GameObject fallingObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
        Rigidbody rb = fallingObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = new Vector3(0, -currentFallSpeed, 0); // ÷»ÿ ”—⁄… «·”ﬁÊÿ
        }
    }
}
