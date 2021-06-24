using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AuthManager : MonoBehaviour
{

    /// <summary>
    /// Login Input Field
    /// </summary>
    public InputField loginField;

    /// <summary>
    /// Password Input Field
    /// </summary>
    public InputField passwordField;

    // test
    Dictionary<string, string> database;

    public void Awake()
    {
        // Code - connetcting to DataBase. 

        // for test
        database = new Dictionary<string, string>();
        database.Add("player", "123");
    }

    /// <summary>
    /// Click on enter button - auth user in the system SDO
    /// </summary>
    public void LoginIn()
    {

        // Getting data from Login Field
        string inputedLogin = loginField.text;

        // Getting data from Password Field
        string inputedPassword = passwordField.text;

        foreach (var user in database)
        {
            if (user.Key == inputedLogin)
            {
                if (user.Value == inputedPassword)
                {
                    SceneManager.LoadScene(1);

                    Debug.Log("User is logged");
                    break;
                };
            }
        }


        Debug.Log("User is not logged");
    }

    public void ExitFromApp()
    {
        Debug.Log("Exiting from app...");
        Application.Quit();
    }



}
