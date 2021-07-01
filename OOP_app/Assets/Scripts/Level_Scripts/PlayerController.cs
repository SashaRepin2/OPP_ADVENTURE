using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float MoveInput;

    public Joystick joystick;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private Animator anim;
    //Позиция игрока. Необходима для перехода между локациями
    public VectorValue pos;

    private void Start()
    {
        transform.position = pos.initialValue;
        //Получаем риджидбади
        rb = GetComponent<Rigidbody2D>();
        //Получаем аниматор
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //Движение только по горизонтальной оси
        MoveInput = joystick.Horizontal;
        //Задаем движение по горизонтальной оси с учетом скорости, по вертикальной оставляем как есть
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);
        //Меняем разворот персонажа если он идет влево и клавиша нажата влево
        if(facingRight == false && MoveInput > 0)
        {
            Flip();
        }
        else
        {
            //Меняем разворот персонажа если он идет вправо и клавиша нажата вправо
            if (facingRight == true && MoveInput < 0)
            {
                Flip();
            }
        }
        //Если персонаж не двигается, то анимация параметр IsWalking в аниматоре = false и наоборот
        if(MoveInput == 0)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }
    }
    /// <summary>
    /// Разворачиваем персонажа
    /// </summary>
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
