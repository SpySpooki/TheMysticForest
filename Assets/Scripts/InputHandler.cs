using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

    public void ValidateInput()
    {
        string input = inputField.text;

        if (input.Equals("You made the wrong choices so now you will support the consequences"))
        {
          
            // Load the next scene
            SceneManager.LoadScene("Scene50");
        }
        else
        {
            resultText.text = "Invalid input";
            resultText.color = Color.red;
            // Reload the current scene with a fade effect
            ReloadSceneWithFade();
        }
    }

    public void OnButtonClick()
    {
        ValidateInput();
    }

    void ReloadSceneWithFade()
    {
        Debug.Log("Reloading scene with fade effect.");
        // Use the fade effect
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1f);
    }
}
