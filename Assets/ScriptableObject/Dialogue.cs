using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string text; // The dialogue text
    public Sprite leftImage; // Image for the left spawn point
    public Sprite rightImage; // Image for the right spawn point
    public DialogueChoice[] choices; // Choices available after this line, if any
}

[System.Serializable]
public class Dialogue
{
    public DialogueLine[] lines; // Array of dialogue lines
}
[System.Serializable]
public class DialogueChoice
{
    public string choiceText; // Text to display for the choice
    public Dialogue followUpDialogue; // Dialogue to follow if this choice is selected
}