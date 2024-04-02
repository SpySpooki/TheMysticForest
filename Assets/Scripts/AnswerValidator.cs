using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerValidator : MonoBehaviour
{
    public InputField inputField;
    public string correctInput;

    public void CheckInputAndLoadScene()
    {
        string userInput = inputField.text.Trim();

        if (userInput.Equals(correctInput))
        {
            SceneManager.LoadScene("SceneNameToLoad");
        }
        else
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Incorrect input. Please try again.");
            // You can add additional feedback for the user, like displaying an error message.
        }
    }
}
