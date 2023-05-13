using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UsersData
{
    public static List<User> users = new List<User>();

    public static bool CheckForLogin(string log)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].login == log)
            {
                return false;
            }
        }
        return true;
    }

    public static bool CheckForUser(string log, string pass) 
    {
        for (int i = 0; i < UsersData.users.Count; i++)
        {
            if (users[i].login == log && users[i].password == pass)
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
}