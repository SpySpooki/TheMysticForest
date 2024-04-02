// SceneTraitsConfig.cs
using UnityEngine;

[System.Serializable]
public class TraitModification
{
    public string traitName;
    public int modificationAmount;
}

public class TraitsConfig : MonoBehaviour
{
    public TraitModification[] modifications;

    void Start()
    {
        ApplyModifications();
    }

    void ApplyModifications()
    {
        if (TraitsManager.Instance == null)
        {
            Debug.LogError("TraitsManager instance is null.");
            return;
        }

        foreach (var mod in modifications)
        {
            TraitsManager.Instance.UpdateTrait(mod.traitName, mod.modificationAmount);
        }
    }
}