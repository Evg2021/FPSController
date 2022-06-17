using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndMove : MonoBehaviour
{
    
    public GameObject otherGameObject; //для обьекта FPSController
    public GameObject fps;
    public CharacterController characterController;
    public float step;
    public float angleStep;
    private PlayerMovement playerMovement;
    

    private void OnValidate()
    {
        if (otherGameObject == null)
        {
            otherGameObject = GameObject.Find("FPSController");
        }
    }

    void Start()
    {
        
        if (otherGameObject != null)
        {
            playerMovement = otherGameObject.GetComponent<PlayerMovement>();
        }

        fps = GameObject.Find("FPSController");
    }

    
    void Update()
    {
        if (characterController != null)
        {            
            characterController.Move(characterController.transform.forward * step);
            characterController.transform.Rotate(0, angleStep * Time.deltaTime, 0);
        }

        if (playerMovement != null)
        {
            if (Input.GetKey(KeyCode.J))
            {
                playerMovement.transform.position = new Vector3(0, 0, 0);
            }
        }

        //if (fps != null)
        //{
        //     fps.transform.Rotate(0, angleStep * Time.deltaTime, 0);
        //}


        
    }


    
}
