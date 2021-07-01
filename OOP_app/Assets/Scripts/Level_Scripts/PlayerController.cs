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
    //������� ������. ���������� ��� �������� ����� ���������
    public VectorValue pos;

    private void Start()
    {
        transform.position = pos.initialValue;
        //�������� ����������
        rb = GetComponent<Rigidbody2D>();
        //�������� ��������
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //�������� ������ �� �������������� ���
        MoveInput = joystick.Horizontal;
        //������ �������� �� �������������� ��� � ������ ��������, �� ������������ ��������� ��� ����
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);
        //������ �������� ��������� ���� �� ���� ����� � ������� ������ �����
        if(facingRight == false && MoveInput > 0)
        {
            Flip();
        }
        else
        {
            //������ �������� ��������� ���� �� ���� ������ � ������� ������ ������
            if (facingRight == true && MoveInput < 0)
            {
                Flip();
            }
        }
        //���� �������� �� ���������, �� �������� �������� IsWalking � ��������� = false � ��������
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
    /// ������������� ���������
    /// </summary>
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
