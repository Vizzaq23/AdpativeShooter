using UnityEngine;

public class PerformanceTracker : MonoBehaviour
{
    public int totalShots = 0;
    public int hits = 0;

    public float totalReactionTime = 0f;
    public int reactionSamples = 0;

    public void RegisterShot()
    {
        totalShots++;
    }

    public void RegisterHit()
    {
        hits++;
    }

    public void RegisterReactionTime(float reactionTime)
    {
        totalReactionTime += reactionTime;
        reactionSamples++;
    }

    public float GetAccuracy()
    {
        if (totalShots == 0) return 0f;
        return (float)hits / totalShots * 100f;
    }

    public float GetAverageReactionTime()
    {
        if (reactionSamples == 0) return 0f;
        return totalReactionTime / reactionSamples;
    }
}