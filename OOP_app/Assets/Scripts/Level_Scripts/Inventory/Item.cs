using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public int i; //Номер слота
    public Canvas[] canvases;
    private Animator anim;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        //Если в слоте нет предметов, то он пустой
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void ShowItem()
    {
        Transform item = inventory.items[i].transform.GetChild(0);
        switch (item.tag)
        {
            case "Node":
                foreach(Canvas elem in canvases)
                {
                    if(elem.tag == item.tag)
                    {
                        anim = elem.GetComponent<Animator>();
                        anim.SetBool("canvasOpen", true);
                    }
                }
                break;
            case "SecondNode":
                foreach (Canvas elem in canvases)
                {
                    if (elem.tag == item.tag)
                    {
                        anim = elem.GetComponent<Animator>();
                        anim.SetBool("canvasOpen", true);
                    }
                }
                break;
            case "ThirdNode":
                foreach (Canvas elem in canvases)
                {
                    if (elem.tag == item.tag)
                    {
                        anim = elem.GetComponent<Animator>();
                        anim.SetBool("canvasOpen", true);
                    }
                }
                break;
            default: break;
        }
    }
    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
