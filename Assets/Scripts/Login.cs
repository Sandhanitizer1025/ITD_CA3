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
        if (passwordInput.text == correctPassword)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            errorText.SetActive(true);
        }
    }
}

