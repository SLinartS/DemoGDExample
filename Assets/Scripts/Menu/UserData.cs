using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    private static List<User> users = new List<User>();

    public static bool RegistrationUser(string login, string password)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            return false;
        }

        User newUser = new User(login, password);
        users.Add(newUser);
        return true;
    }

    public static bool CheckLogin(string login)
    {
        if (string.IsNullOrEmpty(login))
        {
            return false;
        }

        for (int i = 0; i < users.Count; i++)
        {
            if (login == users[i].login)
            {
                return false;
            }
        }

        return true;
    }

    public static bool LoginUser(string login, string password)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (login == users[i].login && password == users[i].password)
            {
                return true;
            }
        }
        return false;
    }
}

public class User
{
    public string login;
    public string password;

    public User(string login, string password)
    {
        this.login = login;
        this.password = password;
    }
}
