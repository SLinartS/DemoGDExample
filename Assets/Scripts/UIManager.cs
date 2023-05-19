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
            Debug.Log("������");
            return;
        }
        
        if(UserData.CheckUser(login, password))
        {
            Debug.Log("�� ����������");
            authWindow.SetActive(false);
            menuWindow.SetActive(true);
            
            return;
        };
        Debug.Log("������ ������ ��� ������");
    }

    public void Reg()
    {
        string login = loginReg.text;
        string password = passwordReg.text;

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            Debug.Log("������");
            return;
        }

        if (!UserData.CheckLogin(login))
        {
            Debug.Log("������ x2");
            return;
        }

        if (UserData.UserCreate(login, password))
        {
            Debug.Log("�� regnyti");
            regWindow.SetActive(false);
            authWindow.SetActive(true);

            return;
        };
        Debug.Log("������ ������ ��� ������");
    }
}
