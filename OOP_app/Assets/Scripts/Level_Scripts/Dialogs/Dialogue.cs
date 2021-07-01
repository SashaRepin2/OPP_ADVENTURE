using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Необходимо для сохранения
public class Dialogue
{
    public string name;
    [TextArea(3, 10)] //Минимальное и максимальное количество строк в диалоге
    public string[] sentences;
}
