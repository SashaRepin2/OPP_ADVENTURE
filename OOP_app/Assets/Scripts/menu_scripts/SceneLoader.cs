using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    /// <summary>
    /// Scene. Default is 0
    /// </summary>
    public int numberOfScene = 0;

    /// <summary>
    /// Func loading scene
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(numberOfScene);
    }
}
