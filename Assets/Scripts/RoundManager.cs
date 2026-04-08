using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public float roundTime = 30f;
    private float timeRemaining;

    public bool roundActive = false;
    public GameObject gameOverText;
    public GameObject restartButton;

    void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }
    }

    void Update()
    {
        if (!roundActive) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            roundActive = false;

            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            if (restartButton != null)
            {
                restartButton.SetActive(true);
            }

            GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
            foreach (GameObject t in targets)
            {
                Destroy(t);
            }

            Debug.Log("GAME OVER");
        }
    }

    public void StartRound()
    {
        timeRemaining = roundTime;
        roundActive = true;

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }
}