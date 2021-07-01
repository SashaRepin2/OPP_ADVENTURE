using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class EncapsulationGame : MonoBehaviour
{
    public Canvas resultCanvas;
    public TextMeshProUGUI resultText;

    public Button interButt;
    public Button realizButt;

    private List<string> inter = new List<string>();
    private List<string> realiz = new List<string>();

    public List<Sprite> correctAnswerInter;
    public List<Sprite> correctAnswerRealiz;
    public List<Sprite> elements;

    public Image currentImage;

    private int count = 0;
    private bool isPlaying = true;


    void Start()
    {
        resultCanvas.enabled = false;
        currentImage.sprite = elements[count];
    }

    public void CheckResults()
    {
        isPlaying = false;

        int result = CountinrResults();
        Debug.Log("Результат:" + result);

        resultText.text = "Result: " + result + "/" + elements.Count;
        resultCanvas.enabled = true;
        //смена сцены, наверное, после того, как были разбросаны все картинки;

    }

    public void InInterface()
    {
        if (count < 5 && isPlaying)
        {
            inter.Add(currentImage.sprite.name);

            if (count == 4)
            {
                CheckResults();
            }
            else
            {
                count++;
                currentImage.sprite = elements[count];
            }
        }
        else
        {
            CheckResults();
        }
    }

    public void InRealization()
    {


        if (count < 5 && isPlaying)
        {
            realiz.Add(currentImage.sprite.name);

            if (count == 4)
            {
                CheckResults();
            }
            else
            {
                count++;
                currentImage.sprite = elements[count];
            }
        }
        else
        {
            CheckResults();
        }

    }

    public int CountinrResults()
    {

        int gradel = 0;

        foreach (string answer in inter)
        {
            foreach (Sprite correctAnswer in correctAnswerInter)
            {
                Debug.Log(correctAnswer);
                Debug.Log(answer);
                Debug.Log(correctAnswer.name == answer);
                Debug.Log("-------------------------");
                if (correctAnswer.name == answer)
                    gradel++;
            }
        }

        foreach (string answer in realiz)
        {
            foreach (Sprite correctAnswer in correctAnswerRealiz)
            {
                Debug.Log(correctAnswer);
                Debug.Log(answer);
                Debug.Log(correctAnswer.name == answer);
                Debug.Log("-------------------------");

                if (correctAnswer.name == answer)
                    gradel++;
            }
        }
        return gradel;
    }
}
