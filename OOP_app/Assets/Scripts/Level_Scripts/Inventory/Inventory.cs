using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] items;
    public GameObject inventory;
    private bool InventoryOn; //Проверка на влюченный инвент
    private void Start()
    {
        InventoryOn = false;
    }
    public void Chest()
    {
        if(InventoryOn == false)
        {
            InventoryOn = true;
            inventory.SetActive(true);
        }
        else
        {
            InventoryOn = false;
            inventory.SetActive(false);
        }
    }
}
