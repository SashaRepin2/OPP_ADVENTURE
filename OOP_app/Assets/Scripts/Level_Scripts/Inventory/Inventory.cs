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
        inventory.SetActive(InventoryOn);
    }
    public void Chest()
    {
        if (!InventoryOn)
        {
            InventoryOn = true;
            inventory.SetActive(InventoryOn);
        }
        else
        {
            InventoryOn = false;
            inventory.SetActive(InventoryOn);
        }
    }
}
