using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt("LastLoaded", 1);
        PlayerPrefs.SetInt("ReachedIndex", 1);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(1);
    }

    public void ContinueGame()
    {
        PlayerPrefs.GetInt("ReachedIndex", PlayerPrefs.GetInt("LastLoaded", 1));
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("ReachedIndex", 1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
