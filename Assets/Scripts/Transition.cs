using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public string scene;

    public void GoFade()
    {
        SaveData data = new SaveData
        {
            sceneName = scene,
            happiness = TraitsManager.Instance.happiness,
            courage = TraitsManager.Instance.courage,
            friendship = TraitsManager.Instance.friendship
        };
        SaveSystem.SaveGame(data);

        Initiate.Fade(scene, Color.black, 1f);
    }
}