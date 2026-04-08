using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PerformanceTracker tracker;
    public TextMeshProUGUI statsText;

    void Update()
    {
        statsText.text =
            "Shots: " + tracker.totalShots +
            "\nHits: " + tracker.hits +
            "\nAccuracy: " + tracker.GetAccuracy().ToString("F1") + "%" +
            "\nAvg Reaction Time: " + tracker.GetAverageReactionTime().ToString("F2") + "s";
    }
}