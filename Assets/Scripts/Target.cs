using UnityEngine;

public class Target : MonoBehaviour
{
    private float spawnTime;
    public float lifetime = 3f; // Time before the target disappears    

    void Start()
    {
        spawnTime = Time.time;
        Destroy(gameObject, lifetime);
    }

    public void Hit(PerformanceTracker tracker)
    {
        float reactionTime = Time.time - spawnTime;

        tracker.RegisterReactionTime(reactionTime);

        Debug.Log("Target hit! Reaction Time: " + reactionTime + " seconds");

        Destroy(gameObject);
    }
}