using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    public SceneSaveLoadManager sceneSaveLoadManager;

    public void OnLoadSceneButtonClick()
    {
        sceneSaveLoadManager.LoadSavedScene();
    }
}
