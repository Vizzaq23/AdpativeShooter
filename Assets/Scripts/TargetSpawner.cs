using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnInterval = 1.5f;

    public float xRange = 6f;
    public float minY = 1f;
    public float maxY = 5f;
    public float minZ = 6f;
    public float maxZ = 16f;

    public RoundManager roundManager;

    private float spawnTimer = 0f;

    void Update()
    {
        if (roundManager == null) return;

        // 🔴 stop spawning when round is not active
        if (!roundManager.roundActive)
        {
            spawnTimer = 0f; // reset timer
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnTarget();
            spawnTimer = 0f;
        }
    }

    void SpawnTarget()
    {
        float x = Random.Range(-xRange, xRange);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(minZ, maxZ);

        Vector3 spawnPosition = new Vector3(x, y, z);
        Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
    }
}