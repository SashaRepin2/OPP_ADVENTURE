using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Func loading scene using number of scene.
    /// </summary>
    public void LoadSceneByIndex(int numberOfScene = 0)
    {
        SceneManager.LoadScene(numberOfScene);
    }

    /// <summary>
    /// Func loading scene by name
    /// </summary>
    /// <param name="nameOfScene"></param>
    public void LoadSceneByName(string nameOfScene = "menu")
    {
        SceneManager.LoadScene(nameOfScene);
    }
}
