using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    InputField inputLoginReg;
    [SerializeField]
    InputField inputPasswordReg;

    [SerializeField]
    InputField inputLoginAuth;
    [SerializeField]
    InputField inputPasswordAuth;

    [SerializeField]
    GameObject regWindow;
    [SerializeField]
    GameObject authWindow;
    [SerializeField]
    GameObject menuWindow;

    [SerializeField]
    GameObject messageWindow;
    [SerializeField]
    Text messageWindowText;

    GameObject lastWindow;

    public void Registration()
    {
        string login = inputLoginReg.text;
        string password = inputPasswordReg.text;

        if (!UserData.CheckLogin(login))
        {
            lastWindow = regWindow;
            lastWindow.SetActive(false);
            messageWindowText.text = "Такой логин уже существует";
            messageWindow.SetActive(true);
            return;
        }

        if (UserData.RegistrationUser(login, password))
        {
            inputLoginAuth.text = "";
            inputPasswordAuth.text = "";
            inputLoginReg.text = "";
            inputPasswordReg.text = "";
            regWindow.SetActive(false);
            authWindow.SetActive(true);
        }
        else
        {
            lastWindow = regWindow;
            lastWindow.SetActive(false);
            messageWindowText.text = "Ошибка ввода логина или пароля";
            messageWindow.SetActive(true);
        }
    }

    public void Login()
    {
        string login = inputLoginAuth.text;
        string password = inputPasswordAuth.text;

        if (UserData.LoginUser(login, password))
        {
            authWindow.SetActive(false);
            menuWindow.SetActive(true);
        }
        else
        {
            Debug.Log("Error");
            lastWindow = authWindow;
            lastWindow.SetActive(false);
            messageWindowText.text = "Ошибка логина или пароля";
            messageWindow.SetActive(true);
        }
    }

    public void CloseMessageWindow()
    {
        messageWindow.SetActive(false);
        lastWindow.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
