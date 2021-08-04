using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidbody2D;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //If left arrow pressed will output -1 if to the right it will go 1;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //Fixed update works as update does its executed on a fixed timer this is useful for physics
    void FixedUpdate() 
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
