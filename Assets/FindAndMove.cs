using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndMove : MonoBehaviour
{
    
    public GameObject otherGameObject; //для обьекта FPSController
    public GameObject fps;
    private PlayerMovement playerMovement;
    
    
    void Start()
    {
        
        playerMovement = otherGameObject.GetComponent<PlayerMovement>();
        
        fps = GameObject.Find("FPSController");
    }

    
    void Update()
    {
        if (playerMovement != null)
        {
            if (Input.GetKey(KeyCode.J))
            {
                playerMovement.transform.position = new Vector3(0, 0, 0);
            }
        }

        if (fps != null)
        {
            fps.transform.Rotate(0, 100 * Time.deltaTime, 0);
        }
        
    }
}
