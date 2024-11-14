using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("UnlockedLevel", 1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
