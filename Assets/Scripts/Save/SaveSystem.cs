using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public static class SaveSystem
{
    public static void SaveCurrentGameState()
    {
        SaveData currentSaveData = new SaveData
        {
            sceneName = SceneManager.GetActiveScene().name,
        // happiness = // capture current happiness,
        // courage = // capture current courage,
        // friendship = // capture current friendship
    };
        Debug.Log($"{SceneManager.GetActiveScene().name}");
        SaveGame(currentSaveData);
    }

    public static void SaveGame(SaveData data)
    {
        PlayerPrefs.SetString("SceneName", data.sceneName);
        PlayerPrefs.SetInt("Happiness", data.happiness);
        PlayerPrefs.SetInt("Courage", data.courage);
        PlayerPrefs.SetInt("Friendship", data.friendship);
        PlayerPrefs.Save();
    }

    public static SaveData LoadGame()
    {
        SaveData data = new SaveData();
        data.sceneName = PlayerPrefs.GetString("SceneName", SceneManager.GetActiveScene().name);
        data.happiness = PlayerPrefs.GetInt("Happiness", 0);
        data.courage = PlayerPrefs.GetInt("Courage", 0);
        data.friendship = PlayerPrefs.GetInt("Friendship", 0);
        return data;
    }

    public static void NewGame()
    {
        PlayerPrefs.DeleteAll();
        // Optionally, set initial values for a new game
        PlayerPrefs.SetString("SceneName", "Scene1");
        PlayerPrefs.SetInt("Happiness", 0);
        PlayerPrefs.SetInt("Courage", 0);
        PlayerPrefs.SetInt("Friendship", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Scene1");
    }
}