using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressController : MonoBehaviour
{

    public ArrayList levelsInfo;


    // Start is called before the first frame update
    void Start()
    {
        levelsInfo = new ArrayList();

        if (!PlayerPrefs.HasKey("GeneralProgress")) { 

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
