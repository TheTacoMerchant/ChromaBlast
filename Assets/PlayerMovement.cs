using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    //Vector2 movement;

    public KeyCode Backward = KeyCode.S;
    public KeyCode Forward = KeyCode.W;
    public KeyCode Right = KeyCode.D;
    public KeyCode Left = KeyCode.A;
    public float moveVec = 0.25f;
    public float turnRadius = 15f;

    void Update()
    {
        /*movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;*/

        if(Input.GetKey(Forward)){
            transform.Translate(new Vector3(0,moveVec,0) * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(Backward)){
            transform.Translate(new Vector3(0,-moveVec,0) * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(Right)){
            transform.Rotate(new Vector3(0,0,-turnRadius) * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(Left)){
            transform.Rotate(new Vector3(0,0,turnRadius) * movementSpeed * Time.deltaTime);
        }
    }

    /*void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed);
    }*/
}
