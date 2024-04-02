using UnityEngine;
using TMPro;

public class TraitsManager : MonoBehaviour
{
    public static TraitsManager Instance;

    public int happiness = 0;
    public int courage = 0;
    public int friendship = 0;

    // Assign these tags to your UI Text objects in the Unity Editor.
    private readonly string happinessUITag = "HappinessUITag";
    private readonly string courageUITag = "CourageUITag";
    private readonly string friendshipUITag = "FriendshipUITag";

    private TextMeshProUGUI happinessText;
    private TextMeshProUGUI courageText;
    private TextMeshProUGUI friendshipText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize UI references
        InitializeUITraits();
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        InitializeUITraits();
        //OnGameLoaded(); // Apply loaded data here.
    }
    private void OnEnable()
    {
        // Subscribe to the scene loaded event
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void InitializeUITraits()
    {
        // Find and assign UI text components based on their tags
        GameObject happinessUIObj = GameObject.FindGameObjectWithTag(happinessUITag);
        if (happinessUIObj)
        {
            happinessText = happinessUIObj.GetComponent<TextMeshProUGUI>();
        }

        GameObject courageUIObj = GameObject.FindGameObjectWithTag(courageUITag);
        if (courageUIObj)
        {
            courageText = courageUIObj.GetComponent<TextMeshProUGUI>();
        }

        GameObject friendshipUIObj = GameObject.FindGameObjectWithTag(friendshipUITag);
        if (friendshipUIObj)
        {
            friendshipText = friendshipUIObj.GetComponent<TextMeshProUGUI>();
        }

        UpdateUI(); // Update UI with initial trait values
    }

    public void UpdateTrait(string traitName, int amount)
    {
        switch (traitName.ToLower())
        {
            case "happiness":
                happiness += amount;
                break;
            case "courage":
                courage += amount;
                break;
            case "friendship":
                friendship += amount;
                break;
            default:
                Debug.LogWarning("Unknown trait: " + traitName);
                break;
        }
        UpdateUI(); // Reflect changes in the UI
    }
    /*public void OnGameLoaded()
    {
        SaveData data = SaveSystem.LoadGame();

        // Make sure the TraitsManager instance is ready before applying values.
        TraitsManager.Instance.happiness = data.happiness;
        TraitsManager.Instance.courage = data.courage;
        TraitsManager.Instance.friendship = data.friendship;

        // Optionally, update the UI to reflect the new trait values.
        TraitsManager.Instance.UpdateUI();
    }*/

    private void UpdateUI()
    {
        if (happinessText) happinessText.text = "Happiness: " + happiness;
        if (courageText) courageText.text = "Courage: " + courage;
        if (friendshipText) friendshipText.text = "Friendship: " + friendship;
    }
}