using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public RoundManager roundManager;
    public GameObject startButton;

    public void StartGame()
    {
        roundManager.StartRound();
        startButton.SetActive(false);
    }
}