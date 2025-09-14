using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;  // ������ ���� ���� �������
    private float spawnY = 5f;  // ������ ����� �������
    private float screenWidth;  // ��� ������
    private int platformCount = 10;  // ��� �������

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

            // ���� �� �� spawnPosition ����� ��� ��� ������
            if (spawnPosition.y < -5 || spawnPosition.y > 10)
            {
                Debug.LogWarning("������ spawnPosition ��� �����: " + spawnPosition);
            }

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);  // ����� ������
            spawnY += Random.Range(1.5f, 3f);  // ����� Y ����� �������
        }
    }
}
