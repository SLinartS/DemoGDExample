using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] InputField loginAuth;
    [SerializeField] InputField passwordAuth;

    [SerializeField] InputField loginReg;
    [SerializeField] InputField passwordReg;

    [SerializeField] GameObject menuWindow;
    [SerializeField] GameObject regWindow;
    [SerializeField] GameObject authWindow;

    public void Auth()
    {
        string login = loginAuth.text;
        string password = passwordAuth.text;

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Ошибка");
            return;
        }
        
        if(UserData.CheckUser(login, password))
        {
            Debug.Log("Вы залогинены");
            authWindow.SetActive(false);
            menuWindow.SetActive(true);
            
            return;
        };
        Debug.Log("Ошибка логина или пароля");
    }

    public void Reg()
    {
        string login = loginReg.text;
        string password = passwordReg.text;

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Ошибка");
            return;
        }

        if (!UserData.CheckLogin(login))
        {
            Debug.Log("Ошибка x2");
            return;
        }

        if (UserData.UserCreate(login, password))
        {
            Debug.Log("Вы regnyti");
            regWindow.SetActive(false);
            authWindow.SetActive(true);

            return;
        };
        Debug.Log("Ошибка логина или пароля");
    }
}
