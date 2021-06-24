using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rbFigure;

    /// <summary>
    /// Speed of object
    /// </summary>
    public float movementSpeed = .0015f;

    /// <summary>
    /// Speed of rotate object
    /// </summary>
    public float speedRotate = .2f;

    /// <summary>
    /// Direction of object
    /// </summary>
    public Vector2 direction;

    void Start()
    {
        // Getting component
        rbFigure = GetComponent<Rigidbody2D>();

        // Setting a start direction of object
        SetStartDireaction();
    }

    void FixedUpdate()
    {
        // Rotating object
        rbFigure.transform.Rotate(0, 0, speedRotate);

        // Moving object
        transform.Translate(direction.normalized * movementSpeed);
    }


    private void SetStartDireaction()
    {
        direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));  

        if (direction.x == 0 && direction.y == 0) {
            direction = new Vector2(1, 1);
        }

    }

    private void ChangeDirection()
    {
        direction = direction * (-1);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Square")
        {
            ChangeDirection();
            //rbFigure.transform.Rotate(0, 0, speedRotate);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Frame")
        {
            ChangeDirection();
        }
    }
}
