using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Vector3 position;
    public VectorValue playerStorage;


    /// <summary>
    /// Func loading scene using number of scene.
    /// </summary>
    public void LoadSceneByIndex(int numberOfScene = 0)
    {
        playerStorage.initialValue = position;
        SceneManager.LoadScene(numberOfScene);
    }

    /// <summary>
    /// Func loading scene by name
    /// </summary>
    /// <param name="nameOfScene"></param>
    public void LoadSceneByName(string nameOfScene = "menu")
    {
        playerStorage.initialValue = position;
        SceneManager.LoadScene(nameOfScene);
    }
}
