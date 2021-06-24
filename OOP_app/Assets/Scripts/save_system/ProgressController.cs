using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressController : MonoBehaviour
{

    public void Awake()
    {
        // ≈сли не нашел - значит нова€ игра и возвращет false
        bool isNewGame = PlayerPrefs.HasKey("IsNewGame");

        if (isNewGame)
        {
            ProgressData data = new ProgressData();
            SaveSystem.SaveProgressPlayer(data);
            PlayerPrefs.SetInt("IsNewGame", !isNewGame ? 1 : 0);
        }
        else
        {
            PlayerPrefs.SetInt("IsNewGame", !isNewGame ? 1 : 0);



        }
    }


}
