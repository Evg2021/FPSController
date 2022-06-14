using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Первая реализация
    public float moveSpeed = 10f; // скорость движения вперед
    public float rotateSpeed = 10f; // скорость поворота вокруг оси Y

    public Vector3 offsetBack;
    public Vector3 deltaBack;
    private Vector3 summDeltaBack;

    private Vector3 forw; //  переменная вектор движения вперед
    
    private float vInput; // переменная для хранения координат перемещения вперед WS
    private float hInput; // переменная для хранения координат поворота вокруг AD

    private bool isStoped = false;
    private bool isMoved = false;

    
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


    private void Start()
    {
        StartCoroutine(MoveBack());
    }

    private IEnumerator MoveBack()
    {
        while (isStoped && isMoved)
        {
            transform.position += deltaBack * Time.deltaTime;
            summDeltaBack += deltaBack * Time.deltaTime;
            while (summDeltaBack.magnitude >= offsetBack.magnitude)
            {
                isMoved = false;
                summDeltaBack = Vector3.zero;
            
            }
            yield return null;
        }
        
    }

    public void Update()
    {
        //Первая реализация

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        // реализация движения вперед
        forw = transform.forward * vInput;
        transform.position = forw * Time.deltaTime + transform.position;

        // реализация поворота вокруг оси Y
        
        transform.eulerAngles += new Vector3(0.0f, hInput, 0.0f) * Time.deltaTime;

        // релизация откатывания назад после остановки движения
        if ((int)vInput == 0 && (int)hInput == 0 && isMoved)
        {
            isStoped = true;
        }
        else if ((int)vInput != 0 || (int)hInput != 0)
        {
            isMoved = true;
            isStoped = false;
        }

        /*if (isStoped && isMoved) // реализуем откат в корутине
        {
            transform.position += deltaBack * Time.deltaTime;
            summDeltaBack += deltaBack * Time.deltaTime;
            if (summDeltaBack.magnitude >= offsetBack.magnitude)
            {
                isMoved = false;
                summDeltaBack = Vector3.zero;
            }
        } */



        //move = transform.right * hInput;
        //rotate = transform.forward * vInput;

        //transform.position = (move + rotate) * Time.deltaTime + transform.position;
        //transform.position = move * Time.deltaTime + transform.position;



        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);

        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);

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
