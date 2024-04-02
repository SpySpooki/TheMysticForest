using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Image leftDialogueImage;
    public Image rightDialogueImage;
    public Dialogue dialogue;
    public Button choiceButtonPrefab;
    public GameObject choicesContainer;
    private bool showingChoices = false;


    [SerializeField]
    private TraitModification[] traitModifications; // Configure in Inspector

    private int currentLineIndex = 0;

    void Start()
    {
        ShowDialogue();
    }

    void Update()
    {
        if ((!showingChoices && Input.GetMouseButtonDown(0)) || (!showingChoices && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) // Only advance dialogue if choices are not being shown
        {
            DisplayNextLine();
        }
    }

    void ShowDialogue()
    {
        currentLineIndex = 0;
        UpdateDialogueUI(dialogue.lines[currentLineIndex]);
    }

    void DisplayNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogue.lines.Length)
        {
            UpdateDialogueUI(dialogue.lines[currentLineIndex]);
        }
        else
        {
            ShowChoices();
        }
    }

    void UpdateDialogueUI(DialogueLine line)
    {
        if (line != null)
        {
            if (dialogueText != null)
            {
                dialogueText.text = line.text;
            }

            if (leftDialogueImage != null)
            {
                leftDialogueImage.sprite = line.leftImage;
                leftDialogueImage.gameObject.SetActive(line.leftImage != null);
            }

            if (rightDialogueImage != null)
            {
                rightDialogueImage.sprite = line.rightImage;
                rightDialogueImage.gameObject.SetActive(line.rightImage != null);
            }
        }
    }
    void ShowChoices()
    {
        showingChoices = true; // Indicate that choices are now being shown
        choicesContainer.SetActive(true);
    }

    public void ApplyTraitModification(int index)
    {
        if (index >= 0 && index < traitModifications.Length)
        {
            TraitsManager.Instance.UpdateTrait(traitModifications[index].traitName, traitModifications[index].modificationAmount);
            choicesContainer.SetActive(false); // Hide choices after selection
            showingChoices = false; // No longer showing choices
        }
    }

    void CreateChoiceButton(string choiceText, string sceneName)
    {
        Button choiceButton = Instantiate(choiceButtonPrefab, choicesContainer.transform);
        choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choiceText;
        choiceButton.onClick.AddListener(delegate { OnChoiceSelected(sceneName); });
    }

    void OnChoiceSelected(string sceneName)
    {
        Initiate.Fade(sceneName, Color.black, 1f); // Use the fade transition to load the scene
    }
}