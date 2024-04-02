using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // For TextMeshProUGUI

public class ButtonManager : MonoBehaviour
{
    public GameObject buttonsParent; // Parent object containing all the buttons
    private bool gameStarted = false;
    public float timer = 10f; // MODIFY THIS LINE: Timer duration, now adjustable in the Inspector
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component for the timer
    public string targetSceneName; // Name of the scene to move to, assignable in the Inspector

    void Start()
    {
        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            ActivateButtons();
            if (timerText != null)
            {
                timerText.gameObject.SetActive(true);
            }
        }

        if (gameStarted)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();
            if (timer <= 0)
            {
                ReloadSceneWithFade();
            }
        }
    }

    void ActivateButtons()
    {
        foreach (Transform child in buttonsParent.transform)
        {
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                child.gameObject.SetActive(true);
                button.onClick.AddListener(() => ButtonClicked(button));
            }
        }
    }

    void ButtonClicked(Button button)
    {
        Debug.Log("Button clicked: " + button.gameObject.name);
        Destroy(button.gameObject);
        Invoke(nameof(CheckAllButtonsClicked), 0.1f);
    }

    void CheckAllButtonsClicked()
    {
        if (buttonsParent.GetComponentsInChildren<Button>().Length == 0)
        {
            Debug.Log("All buttons clicked. Changing scene.");
            Initiate.Fade(targetSceneName, Color.black, 1f);
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F2");
            if (timer < 0)
            {
                timerText.text = "Time: 0.00";
            }
        }
    }

    void ReloadSceneWithFade()
    {
        Debug.Log("Time's up. Reloading scene.");
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1f);
    }
}