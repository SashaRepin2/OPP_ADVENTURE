using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveResultMiniGame : MonoBehaviour
{
    public void OnClickSaveButton()
    {
        if (SaveSystem.SaveFileExist())
        {
            ProgressData data = SaveSystem.LoadProgress();

            (data.Levels[1] as Level).isCompleted = true;
            (data.Levels[2] as Level).isOpened = true;

            SaveSystem.SaveProgress(data);
        }

        SceneManager.LoadScene("menu_levels");
    }
}
