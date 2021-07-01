using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesTaskCanvas : MonoBehaviour
{
    public Canvas inputMailUI;

    public void Start()
    {
        inputMailUI.enabled = true;
    }

    public void ClickCloseUI()
    {
        inputMailUI.enabled = false;
    }

    public void ClickOpenUI()
    {
        inputMailUI.enabled = true;
    }
}

