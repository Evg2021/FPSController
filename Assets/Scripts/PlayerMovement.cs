using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Первая реализация
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    private float vInput;
    private float hInput;
    
    //Вторая реализация
    //public CharacterController controller;
    //public Transform groundCheck;
    //public LayerMask groundMask;
    //public float speed = 10f;
    //public float jumpHeight = 3f;

    //public float groundDistance = 0.4f;

    //public float gravity = - 9.8f;
    //Vector3 velocity;
    //bool isGrounded;


   

    public void Update()
    {
        //Первая реализация

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);

        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);

    //Вторая реализация
    //    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
    //    if(isGrounded && velocity.y < 0)
    //    {
    //        velocity.y = -2f;
    //    }

    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //   if(Input.GetButtonDown("Jump") && isGrounded)
    //    {
    //        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    //    }

    //    Vector3 move = transform.right * x + transform.forward * z;
    //    controller.Move(move * speed * Time.deltaTime);

    //    velocity.y += gravity * Time.deltaTime;
    //    controller.Move(velocity * Time.deltaTime);

    //    if (Input.GetKey("c"))
    //    {
    //        controller.height = 1f;
    //    }
    //    else
    //    {
    //        controller.height = 2f;
    //    }
    }
}
