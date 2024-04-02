using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text postDialogText;

    // Other variables and methods as needed...

    public void ShowText()
    {
        // Show the text after the dialog is closed
        postDialogText.gameObject.SetActive(true);
    }
}
