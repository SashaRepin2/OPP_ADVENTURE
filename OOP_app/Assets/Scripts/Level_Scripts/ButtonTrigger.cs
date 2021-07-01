using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject frame; //Активная локация
    public GameObject[] otherFrame; //Массив неактивных локаций

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("IsTriggered"); //Активируем триггер если игрок вошел в зону
            frame.SetActive(true); //Активируем локацию
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
