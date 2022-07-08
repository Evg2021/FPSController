using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationWithBackMoving : MonoBehaviour
{
    public GameObject Pult;
    public float PultRotationSpeed = 1.0f;
    public float PultBackRotationSpeed = 2.0f;
    public Quaternion StartPosition;
    public Quaternion EndPosition;
    public float AngleRotation = 90.0f;
    public Quaternion OffsetPultRotation;
    public Quaternion DeltaOffsetPultRotation;

    private bool isNotRotateble = false;
    private bool isRotateble = false;
    private Coroutine pultRotationRout;
    private Coroutine pultBackRotationRout;
    
    void Start()
        {
            StartPosition = transform.rotation;
            EndPosition = StartPosition * Quaternion.Euler(StartPosition.x, StartPosition.y, AngleRotation); 
            OffsetPultRotation = EndPosition * Quaternion.Euler(EndPosition.x, EndPosition.y, - AngleRotation);            
        }
    private void Update()
    {
        if (isNotRotateble)
        {
            //pultBackRotationRout = StartCoroutine(pultBackRotationRoutine(EndPosition, StartPosition));

            Pult.transform.rotation = Quaternion.Lerp(EndPosition, StartPosition, Time.deltaTime * PultBackRotationSpeed);
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
        pultRotationRout = null;
        isNotRotateble = true; 
    }
    private IEnumerator pultBackRotationRoutine(Quaternion startPosition, Quaternion endPosition)
    {
        float time = 0.0f;
        while (time < 1)
        {
            time += Time.deltaTime * PultBackRotationSpeed;
            Pult.transform.rotation = Quaternion.Lerp(startPosition, endPosition, time);
            yield return new WaitForEndOfFrame();
        }
        pultBackRotationRout = null;
        isRotateble = true;
    }


    public void StartOnClickRoutine()
    {
        if (Pult != null && isRotateble)
        {
            pultRotationRout = StartCoroutine(pultRotationRoutine(StartPosition, EndPosition));
        }
        //if (isNotRotateble)
        //{
        //    //pultBackRotationRout = StartCoroutine(pultBackRotationRoutine(EndPosition, StartPosition));
            
        //    Pult.transform.rotation = Quaternion.Lerp(EndPosition, StartPosition, Time.deltaTime * PultBackRotationSpeed);
        //}

    }

    public void StartOnBackRoutine()
    {
        if (isNotRotateble)
                {
                    pultBackRotationRout = StartCoroutine(pultBackRotationRoutine(EndPosition,StartPosition));
                }
    }
}
