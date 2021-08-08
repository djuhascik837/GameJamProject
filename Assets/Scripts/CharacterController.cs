using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    public Rigidbody2D rigidbody2D;
    Vector3 forward, right;
    public Animator animator;

    void Start() 
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        //Creates a rotation for our right vector. Telling to rotate around x axis.
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.anyKey) {
            Move();
        } else {
            animator.SetBool("isMoving", false);
        }
    }

    
    void Move() 
    {
        
        animator.SetBool("isMoving", true);
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //this makes rotation happen
        transform.forward = heading;
        //This makes movement happen
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
