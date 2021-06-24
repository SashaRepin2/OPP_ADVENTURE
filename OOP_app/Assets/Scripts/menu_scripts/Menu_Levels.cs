using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Levels : MonoBehaviour
{
    public void onBackButtonClick() {
        SceneManager.LoadScene(0);
    }

    public void onProgressButtonClick() {
        SceneManager.LoadScene(2);
    }

    public void onLevelClick()
    {
        SceneManager.LoadScene(3);
    }

}
