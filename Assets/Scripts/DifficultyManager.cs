using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public PerformanceTracker tracker;
    public TargetSpawner spawner;

    public float easySpawnInterval = 2f;
    public float mediumSpawnInterval = 1.2f;
    public float hardSpawnInterval = 0.7f;

    void Update()
{
    float accuracy = tracker.GetAccuracy();

    if (accuracy >= 80f)
    {
        // doing well → make it harder (faster)
        spawner.spawnInterval = 0.7f;
    }
    else if (accuracy >= 50f)
    {
        // medium
        spawner.spawnInterval = 1.2f;
    }
    else
    {
        // struggling → make it easier (slower)
        spawner.spawnInterval = 2f;
    }
       // Debug.Log("Accuracy: " + accuracy + " | Spawn Interval: " + spawner.spawnInterval);
    }
}