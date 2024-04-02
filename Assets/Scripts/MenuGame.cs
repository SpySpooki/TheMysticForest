using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void OnLoadGameClicked()
    {
        SaveData data = SaveSystem.LoadGame();
        Debug.Log($"Saving SceneName as {data.sceneName}");
        // Optionally, apply loaded data (e.g., update TraitsManager with loaded values)
        SceneManager.LoadScene(data.sceneName);
    }

    public void OnNewGameClicked()
    {
        SaveSystem.NewGame();
    }
}