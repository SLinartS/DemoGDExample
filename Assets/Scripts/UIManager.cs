using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField regLogin;
    public InputField regPassword;

    public InputField authLogin;
    public InputField authPassword;

    public GameObject regWindow;
    public GameObject authWindow;
    public GameObject menuWindow;

    public void Registration()
    {

        if (regLogin.text != string.Empty && regPassword.text != string.Empty)
        {
            if (UsersData.CheckForLogin(regLogin.text))
            {
                authWindow.SetActive(true);
                regWindow.SetActive(false);
                Debug.Log("add");
                UsersData.users.Add(new User { login = regLogin.text, password = regPassword.text });
            }
        }
    }

    public void Auth()
    {
        if (UsersData.CheckForUser(authLogin.text, authPassword.text))
        {
            menuWindow.SetActive(true);
            authWindow.SetActive(false);
            Debug.Log("enter");
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
