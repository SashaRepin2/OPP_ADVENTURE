using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Levels : MonoBehaviour
{
    public void onLoadSceneButtonClick(int numberOfScene = 0)
    {
        SceneManager.LoadScene(numberOfScene);
    }

    public void Awake()
    {
        InitializePlayerData();



    }

    private void InitializePlayerData()
    {
   
    }
}
