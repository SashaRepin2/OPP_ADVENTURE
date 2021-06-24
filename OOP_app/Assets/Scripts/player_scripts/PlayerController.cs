using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Joystick joystick;

    private float moveInput;
    private Rigidbody2D rbPayer;

    private void Start()
    {
        rbPayer = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = joystick.Horizontal;
        rbPayer.velocity = new Vector2(moveInput * movementSpeed, rbPayer.velocity.y);


        //var movement = Input.GetAxis("Horizontal");

        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        //if (!Mathf.Approximately(0, movement))
        //{
        //    transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        //}

    }

}
