using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseCanvas : MonoBehaviour
{
    public GameObject inputMailUI;

    public void Awake()
    {
        inputMailUI.SetActive(false);
    }

    public void ClickCloseUI()
    {
        inputMailUI.SetActive(false);
    }

    public void ClickOpenUI()
    {
        inputMailUI.SetActive(true);
    }
}

