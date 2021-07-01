using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ProgressData
{
    private ArrayList levels;

    public ArrayList Levels { get { return levels; } set { levels = value; } }

    public ProgressData(ArrayList array)
    {
        this.levels = array;
    }

    public void ResetProgress()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            Level level = levels[i] as Level;
            level.isCompleted = false;

            if (i == 0)
            {
                level.isOpened = true;
            }
            else
            {
                level.isOpened = false;
            }
        }
    }
}

[System.Serializable]
public class Level
{
    public int NumberOfLevel { get; set; }
    public string NameOfLevel { get; set; }
    public bool isCompleted { get; set; }
    public float ValueOfProgress { get; set; }
    public bool isOpened { get; set; }

    public Level()
    {
        this.NumberOfLevel = 0;
        this.isCompleted = false;
        this.ValueOfProgress = 0;
        this.isOpened = false;
        this.NameOfLevel = "menu";
    }

    public Level(int numberOfLevel, string nameOfLevel, bool isCompleted, bool isOpened, float valueOfProgress)
    {
        this.NumberOfLevel = numberOfLevel;
        this.isCompleted = isCompleted;
        this.ValueOfProgress = valueOfProgress;
        this.isOpened = isOpened;
        this.NameOfLevel = nameOfLevel;
    }
}





