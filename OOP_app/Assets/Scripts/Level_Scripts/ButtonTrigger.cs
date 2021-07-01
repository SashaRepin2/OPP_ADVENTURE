using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject frame; //�������� �������
    public GameObject[] otherFrame; //������ ���������� �������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("IsTriggered"); //���������� ������� ���� ����� ����� � ����
            frame.SetActive(true); //���������� �������
            foreach(GameObject frame in otherFrame)
            {
                frame.SetActive(false);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("IsTriggered");
        }
    }
}
