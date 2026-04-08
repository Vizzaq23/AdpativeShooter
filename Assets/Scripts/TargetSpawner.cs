using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;

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

        if (!roundManager.roundActive)
        {
            spawnTimer = 0f;
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= roundManager.currentSpawnInterval)
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
        GameObject newTarget = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);

        Target targetScript = newTarget.GetComponent<Target>();
        if (targetScript != null)
        {
            targetScript.moveSpeed = roundManager.currentTargetSpeed;
            targetScript.spawnTime = Time.time;
        }

        newTarget.transform.localScale = Vector3.one * roundManager.currentTargetScale;
    }
}