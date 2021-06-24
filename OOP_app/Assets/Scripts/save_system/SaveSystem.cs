using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    private static string path = Application.persistentDataPath + "/progress.save";

    public static void SaveProgressPlayer(ProgressData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        

        FileStream fileStream = new FileStream(path, FileMode.Create);



        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ProgressData LoadProgress() {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(path, FileMode.Open);

            ProgressData data = formatter.Deserialize(fileStream) as ProgressData;
            fileStream.Close();

            return data;
        }
        else {
            Debug.LogError("Save file not found. Path: " + path);
            return null;
        }
    }


}
