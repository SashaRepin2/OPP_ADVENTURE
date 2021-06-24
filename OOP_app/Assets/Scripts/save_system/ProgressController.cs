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
            Test();
        }
        else
        {

            ArrayList temp = new ArrayList();

            temp.Add(new Level(numberOfLevel: 3, isOpened: true, isCompleted: false, valueOfProgress: 25));
            temp.Add(new Level(numberOfLevel: 4, isOpened: false, isCompleted: false, valueOfProgress: 25));
            temp.Add(new Level(numberOfLevel: 5, isOpened: false, isCompleted: false, valueOfProgress: 25));
            temp.Add(new Level(numberOfLevel: 6, isOpened: false, isCompleted: false, valueOfProgress: 25));

            data = new ProgressData(temp);
            SaveSystem.SaveProgress(data);
        }
    }

    private void Test()
    {

        for (int i = 0; i < arrayLevelButtons.Length; i++)
        {
            Level temp = data.Levels[i] as Level;

            arrayLevelButtons[i].interactable = temp.isOpened;
            arrayLockButtons[i].enabled = !temp.isOpened;
            //lockImage.enabled = !temp.isOpened;


        }

    }

}
