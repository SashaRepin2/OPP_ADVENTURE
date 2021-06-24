using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ProgressData
{
    ArrayList levels;

    public ProgressData() {
        levels = new ArrayList();
        levels.Add(new Level(3, false, 25));
        levels.Add(new Level(4, false, 25));
        levels.Add(new Level(5, false, 25));
        levels.Add(new Level(6, false, 25));
    }

    public ProgressData(ArrayList array)
    {
        levels = array;
    }

    public void ResetProgress() {

        foreach (Level level in levels) {
            level.isCompleted = false;
        }
    }
}


public class Level
{
    public int NumberOfLevel { get; set; }
    public bool isCompleted { get; set; }
    public float ValueOfProgress { get; set; }

    public Level()
    {
        this.NumberOfLevel = 0;
        this.isCompleted = false;
        this.ValueOfProgress = 0;
    }

    public Level(int numberOfLevel, bool isCompleted, float valueOfProgress) {
        this.NumberOfLevel = numberOfLevel;
        this.isCompleted = isCompleted;
        this.ValueOfProgress = valueOfProgress;
    }
}





