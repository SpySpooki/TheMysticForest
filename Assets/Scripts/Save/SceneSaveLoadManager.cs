using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaveLoadManager : MonoBehaviour
{
    private const string SavedSceneKey = "savedScene";

    // Call this method to save the current scene name
    public void SaveCurrentScene()
    {
        PlayerPrefs.SetString(SavedSceneKey, SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        Debug.Log("Scene saved: " + SceneManager.GetActiveScene().name);
    }

    // Call this method to load the saved scene
    public void LoadSavedScene()
    {
        if (PlayerPrefs.HasKey(SavedSceneKey))
        {
            string sceneName = PlayerPrefs.GetString(SavedSceneKey);
            SceneManager.LoadScene(sceneName);
            Debug.Log("Loading scene: " + sceneName);
        }
        else
        {
            Debug.Log("No scene saved");
        }
    }
}
