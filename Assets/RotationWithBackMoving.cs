using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationWithBackMoving : MonoBehaviour
{
    public GameObject Pult;
    public float PultRotationSpeed = 5.0f;
    public float PultBackRotationSpeed = 2.0f;
    public Quaternion StartPosition;
    public Quaternion EndPosition;
    public float AngleRotation = 90.0f;
    public Quaternion OffsetPultRotation;
    public Quaternion DeltaOffsetPultRotation;
    public float time;

    private bool isRotationStarted = false;
    private Coroutine pultRotationRout;
   
    
    void Start()
    {
        time = 0.0f;
        StartPosition = Pult.transform.rotation;
        EndPosition = StartPosition * Quaternion.Euler(0.0f, 0.0f, AngleRotation); 
                  
    }
    private void Update()
    {
        if (Pult != null && isRotationStarted)
        {
            time += Time.deltaTime;
            if (time <= 1.0f)
            {                
                Pult.transform.rotation = Quaternion.Lerp(StartPosition, EndPosition, time);
            }
            else if(time > 1.0f)
            {
                Pult.transform.rotation = Quaternion.Lerp(EndPosition, StartPosition, time - 1.0f);
            }
            if (time >= 2.0f)
            {
                isRotationStarted = false;
                time = 0.0f;
            }
        }
            
                            
    }

    private IEnumerator pultRotationRoutine(Quaternion startPosition, Quaternion endPosition)
    {
        float time = 0.0f;
        while (time < 1)
        {
            time += Time.deltaTime * PultRotationSpeed;            
            Pult.transform.rotation = Quaternion.Lerp(startPosition, endPosition, time);
            yield return new WaitForEndOfFrame();
        }
        time = 0.0f;
        while (time < 1)
        {
            time += Time.deltaTime * PultBackRotationSpeed;
            Pult.transform.rotation = Quaternion.Lerp(endPosition, startPosition, time);
            yield return new WaitForEndOfFrame();
        }

        pultRotationRout = null;        
    }
    
    public void StartOnClickRoutine()
    {
        if (Pult != null)
        {
            isRotationStarted = true;
            //pultRotationRout = StartCoroutine(pultRotationRoutine(StartPosition, EndPosition));
        }
        
    }
    
}
