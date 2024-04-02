using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public SceneSaveLoadManager sceneSaveLoadManager;

    public void OnSaveButtonClick()
    {
        sceneSaveLoadManager.SaveCurrentScene();
    }
}
