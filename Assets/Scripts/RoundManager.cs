using UnityEngine;
using TMPro;

public class RoundManager : MonoBehaviour
{
    [Header("Round Settings")]
    public float roundTime = 30f;
    private float timeRemaining;

    [Header("Round State")]
    public bool roundActive = false;

    [Header("UI")]
    public GameObject gameOverText;
    public GameObject endScreenPanel;
    public GameObject liveStatsUI;
    public TextMeshProUGUI finalStatsText;

    [Header("Player Performance")]
    public int shotsFired = 0;
    public int targetsHit = 0;
    public float totalReactionTime = 0f;

    [Header("Adaptive Difficulty Output")]
    public float currentAccuracy = 0f;
    public float averageReactionTime = 1f;
    public float difficultyScore = 0f;

    [Header("Difficulty Settings")]
    public float minSpawnInterval = 0.4f;
    public float maxSpawnInterval = 1.5f;

    public float minTargetSpeed = 1.5f;
    public float maxTargetSpeed = 6f;

    public float minTargetScale = 0.6f;
    public float maxTargetScale = 1.2f;

    [Header("Live Difficulty Values")]
    public float currentSpawnInterval = 1.5f;
    public float currentTargetSpeed = 1.5f;
    public float currentTargetScale = 1.2f;

    void Start()
    {
        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (endScreenPanel != null)
            endScreenPanel.SetActive(false);

        if (liveStatsUI != null)
            liveStatsUI.SetActive(true);

        ResetRoundStats();
    }

    void Update()
    {
        if (!roundActive) return;

        timeRemaining -= Time.deltaTime;
        UpdateDifficulty();

        if (timeRemaining <= 0f)
        {
            EndRound();
        }
    }

    public void StartRound()
    {
        timeRemaining = roundTime;
        roundActive = true;

        ResetRoundStats();

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (endScreenPanel != null)
            endScreenPanel.SetActive(false);

        if (liveStatsUI != null)
            liveStatsUI.SetActive(true);
    }

    void EndRound()
    {
        timeRemaining = 0f;
        roundActive = false;

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (endScreenPanel != null)
            endScreenPanel.SetActive(true);

        if (liveStatsUI != null)
            liveStatsUI.SetActive(false);

        if (finalStatsText != null)
        {
            finalStatsText.text =
                "Shots Fired: " + shotsFired +
                "\nTargets Hit: " + targetsHit +
                "\nAccuracy: " + (currentAccuracy * 100f).ToString("F1") + "%" +
                "\nAvg Reaction Time: " + averageReactionTime.ToString("F2") + "s" +
                "\nSkill Rating: " + GetSkillRating();
        }

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject t in targets)
        {
            Destroy(t);
        }

        Debug.Log("GAME OVER");
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public void RegisterShot()
    {
        shotsFired++;
    }

    public void RegisterHit(float reactionTime)
    {
        targetsHit++;
        totalReactionTime += reactionTime;
    }

    void UpdateDifficulty()
    {
        // Calculate current accuracy as hits divided by total shots fired
        currentAccuracy = shotsFired > 0 ? (float)targetsHit / shotsFired : 0f;

        // Calculate average reaction time across all successful hits
        averageReactionTime = targetsHit > 0 ? totalReactionTime / targetsHit : 1f;

        // Convert accuracy into a 0 to 1 score
        float accuracyScore = Mathf.Clamp01(currentAccuracy);

        // Convert reaction time into a score where faster reactions mean higher difficulty
        float reactionScore = Mathf.Clamp01(1.5f - averageReactionTime);

        // Combine both metrics into one difficulty score
        difficultyScore = (accuracyScore * 0.6f) + (reactionScore * 0.4f);

        // Calculate target gameplay values based on the difficulty score
        float targetSpawnInterval = Mathf.Lerp(maxSpawnInterval, minSpawnInterval, difficultyScore);
        float targetSpeed = Mathf.Lerp(minTargetSpeed, maxTargetSpeed, difficultyScore);
        float targetScale = Mathf.Lerp(maxTargetScale, minTargetScale, difficultyScore);

        // Smooth transitions so difficulty changes feel natural
        float smoothSpeed = 2f;

        currentSpawnInterval = Mathf.Lerp(currentSpawnInterval, targetSpawnInterval, Time.deltaTime * smoothSpeed);
        currentTargetSpeed = Mathf.Lerp(currentTargetSpeed, targetSpeed, Time.deltaTime * smoothSpeed);
        currentTargetScale = Mathf.Lerp(currentTargetScale, targetScale, Time.deltaTime * smoothSpeed);
    }

    public void ResetRoundStats()
    {
        shotsFired = 0;
        targetsHit = 0;
        totalReactionTime = 0f;

        currentAccuracy = 0f;
        averageReactionTime = 1f;
        difficultyScore = 0f;

        currentSpawnInterval = maxSpawnInterval;
        currentTargetSpeed = minTargetSpeed;
        currentTargetScale = maxTargetScale;
    }

    string GetSkillRating()
    {
        float accuracyPercent = currentAccuracy * 100f;

        if (accuracyPercent >= 85f && averageReactionTime <= 0.45f)
            return "Elite";
        else if (accuracyPercent >= 70f && averageReactionTime <= 0.65f)
            return "Advanced";
        else if (accuracyPercent >= 55f && averageReactionTime <= 0.85f)
            return "Intermediate";
        else
            return "Beginner";
    }
}