using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class UserData : MonoBehaviour
{

    static List<User> users = new List<User>();
    // Start is called before the first frame update

    public static bool UserCreate(string login, string password)
    {
        if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
        {
            User user = new User(login, password);
            users.Add(user);
            return true;
        }
        return false;
    }

    public static bool CheckUser(string login, string password)
    {
        if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].login == login && users[i].password == password)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool CheckLogin(string login)
    {
        if (!string.IsNullOrEmpty(login))
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].login == login)
                {
                    return false;
                }
            }
            return true;
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
