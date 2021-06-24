using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChanger : MonoBehaviour
{
    void Start()
    {
        // Adaptive collider 
        gameObject.GetComponent<BoxCollider2D>().size = new Vector3(Screen.width, Screen.height, 0);
    }
}
