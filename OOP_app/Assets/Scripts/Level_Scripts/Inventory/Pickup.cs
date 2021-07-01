using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //��� ���������� ���� ������ � ���������, � �� ��� ������� � ���� ����
            for(int i = 0; i < inventory.items.Length; i++)
            {
                //���� ���� ������, �� ��������� ���
                if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.items[i].transform); //����� ������, � ����� �����
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
