using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryZone : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    void OnTriggerEnter2D(Collider2D collider)
    {
        UnlockNewLevel();
    }

    void UnlockNewLevel()
    {
        if (PlayerPrefs.GetInt("ReachedIndex", 1) < 5)
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("LastLoaded", PlayerPrefs.GetInt("ReachedIndex", 1));
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedLevel"))
            {
                PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            }
            PlayerPrefs.Save();
            player.Win();
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
