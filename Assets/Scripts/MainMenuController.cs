using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadAimTrainer()
    {
        SceneManager.LoadScene("AimTrainer");
    }

    public void LoadEnemySandbox()
    {
        SceneManager.LoadScene("EnemySandbox");
    }
}