using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    public float speedOfRotation = 5.0f;
    public int AngleRotation = 1;
    private Coroutine rotCoroutine;
    

    private IEnumerator PlayerRotation()
    {
        float time = 0.0f;
        while (true)
        {
            time += Time.deltaTime * speedOfRotation;
            transform.Rotate(Vector3.up, AngleRotation);
            yield return new WaitForEndOfFrame();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rotCoroutine = StartCoroutine(PlayerRotation());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(rotCoroutine != null)
            {
                AngleRotation *= -1;
                //StopCoroutine(rotCoroutine);
                //rotCoroutine = null;
            }
            //AngleRotation *=  -1;
            //rotCoroutine = StartCoroutine(PlayerRotation());
            
                
        }
    }
}
