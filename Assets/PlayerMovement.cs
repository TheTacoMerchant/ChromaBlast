using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 0.05f;
    public Rigidbody2D rb;

    public KeyCode Backward = KeyCode.S;
    public KeyCode Forward = KeyCode.W;
    public KeyCode Right = KeyCode.D;
    public KeyCode Left = KeyCode.A;
    public float moveVec = 0.25f;
    public float turnRadius = 15f;

    void Update()
    {
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
}
