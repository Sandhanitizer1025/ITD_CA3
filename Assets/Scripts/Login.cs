using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour
{
    public string correctPassword = "1234";
    public TMPro.TMP_InputField passwordInput;
    public GameObject errorText;
    public string nextSceneName = "NewScene";

    public void OnButtonPressed()
{
    Debug.Log("BUTTON PRESSED");

    if (passwordInput.text.Trim() == correctPassword)
    {
        errorText.SetActive(false);
        SceneManager.LoadScene(nextSceneName);
    }
    else
    {
        errorText.SetActive(true);
    }
}
}

