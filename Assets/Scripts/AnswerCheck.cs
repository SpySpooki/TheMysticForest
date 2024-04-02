using UnityEngine;
using UnityEngine.UI; // For UI components like InputField and Button
using UnityEngine.SceneManagement; // For scene management
using TMPro; // If using TextMeshPro for the InputField

public class AnswerCheck : MonoBehaviour
{
    public TMP_InputField inputField; // Assign in Inspector
    public GameObject correctAnswerObject; // Assign in Inspector, the GameObject to activate upon correct answer

    private string correctAnswer = "You made the wrong choices so now you will support the consequences";

    void Start()
    {
        if (correctAnswerObject != null)
        {
            correctAnswerObject.SetActive(false); // Ensure the object starts deactivated
        }
    }

    public void CheckAnswer()
    {
        if (inputField.text == correctAnswer)
        {
            // Correct answer
            if (correctAnswerObject != null)
            {
                correctAnswerObject.SetActive(true); // Activate the GameObject
            }
        }
        else
        {
            // Incorrect answer, reload the scene with a fade transition
            Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1f);
        }
    }
}