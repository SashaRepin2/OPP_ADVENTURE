using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressController : MonoBehaviour
{
    public Button[] arrayLevelButtons;
    public Image[] arrayLockButtons;

    private ProgressData data;

    public void Awake()
    {
        if (SaveSystem.SaveFileExist())
        {
            data = SaveSystem.LoadProgress();
            OpenLevels();
        }
        else
        {
            ArrayList temp = new ArrayList();

            temp.Add(new Level(numberOfLevel: 3, nameOfLevel: "Level_Inheritance", isOpened: true, isCompleted: false, valueOfProgress: 25));
            temp.Add(new Level(numberOfLevel: 3, nameOfLevel: "Level_Encapsulation", isOpened: false, isCompleted: false, valueOfProgress: 25));
            temp.Add(new Level(numberOfLevel: 0, nameOfLevel: "Unknow", isOpened: false, isCompleted: false, valueOfProgress: 25));
            temp.Add(new Level(numberOfLevel: 0, nameOfLevel: "Unknow", isOpened: false, isCompleted: false, valueOfProgress: 25));

            data = new ProgressData(temp);
            SaveSystem.SaveProgress(data);

            OpenLevels();
        }
    }

    private void OpenLevels()
    {
        for (int i = 0; i < arrayLevelButtons.Length; i++)
        {
            Level temp = data.Levels[i] as Level;

            arrayLevelButtons[i].interactable = temp.isOpened;
            arrayLockButtons[i].enabled = !temp.isOpened;
        }
    }
}
