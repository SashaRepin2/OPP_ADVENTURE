using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public Canvas canvas;
    private Animator anim;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        anim = canvas.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Для заполнения всех слотов в инвентаре, а не все объекты в один слот
            for(int i = 0; i < inventory.items.Length; i++)
            {
                //Если слот пустой, то заполняем его
                if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.items[i].transform); //Какой объект, в каком слоте
                    anim.SetBool("canvasOpen", true);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
    public void CanvasClose()
    {
        anim.SetBool("canvasOpen", false);
    }
}
