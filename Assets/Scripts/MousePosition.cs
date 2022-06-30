using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    
    
    //public Ray ray;
    //public Transform points;
    //public float speed = 10f;
    //private Vector3 pointScreen;
    //private Vector3 offset;

    //private void OnMouseDown()
    //{
    //    pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //    offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z));
    //}

    //private void OnMouseDrag()
    //{
    //    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y, pointScreen.z);
    //    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //    transform.position = curPosition;
    //}
    //public Vector3 screenPosition;
    //public Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //}
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, 100000f))
        //{
        //    points.transform.position = hit.point;
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * speed * Time.deltaTime, Input.GetAxis("Mouse Y") * speed * Time.deltaTime, 0);
        //    transform.Translate(mouse * speed);

        //    //Vector3 mousePos = Input.mousePosition;
        //    //{
        //    //    Debug.Log(mousePos.x);
        //    //    Debug.Log(mousePos.y);
        //    //}
        //}

        //if (Input.GetMouseButtonDown(0))
        //{

        //    this.transform.position = GetMousePosition();
        //    //Debug.Log("onClick");
        //    //Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);  
        //}
        //screenPosition = Input.mousePosition;
        //screenPosition.z = Camera.main.nearClipPlane + 1;

        //worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //transform.position = worldPosition;
    }
    //private void OnMouseDown()
    //{
    //    //this.transform.position = GetMousePosition();
    //}
    //private Vector3 GetMousePosition()
    //{
    //    var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    mousePosition.z = 0;
    //    return mousePosition;
    //}
}
