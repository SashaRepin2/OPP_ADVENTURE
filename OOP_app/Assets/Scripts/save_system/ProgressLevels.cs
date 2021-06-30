using UnityEngine;
using UnityEngine.UI;

public class ProgressLevels : MonoBehaviour
{
    public ProgressBar progressBar;
    public Text[] arrayLevels;
    private ProgressData data;

    public void Awake()
    {
        if (SaveSystem.SaveFileExist())
        {
            data = SaveSystem.LoadProgress();


            int i = 0;

            foreach (Level level in data.Levels)
            {
                if (level.isCompleted)
                    progressBar.currentProgress += level.ValueOfProgress;

                arrayLevels[i].text += level.isCompleted ? " 100%" : " 0%";

                i++;
            }

            if (progressBar.slider.maxValue < progressBar.currentProgress)
                progressBar.currentProgress = progressBar.slider.maxValue;
        }
    }

}
