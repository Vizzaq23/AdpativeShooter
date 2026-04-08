using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public RoundManager roundManager;
    public TextMeshProUGUI statsText;

    void Update()
    {
        if (roundManager == null || statsText == null) return;

        statsText.text =
            "Shots: " + roundManager.shotsFired +
            "\nHits: " + roundManager.targetsHit +
            "\nAccuracy: " + (roundManager.currentAccuracy * 100f).ToString("F1") + "%" +
            "\nAvg Reaction Time: " + roundManager.averageReactionTime.ToString("F2") + "s";
    }
}