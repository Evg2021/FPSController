using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpMovingForwAndBackBySpace : MonoBehaviour
{
    public Transform First;
    public Transform Finish;
    private float speedRunning = 0.2f;
    private Coroutine runningRoutine;
    private Coroutine runningBackRoutine;
    
    private IEnumerator runningRoutineCoroutine(Vector3 start, Vector3 finis)
    {
        float time = 0.0f;
        while (true)
        {
            time += Time.deltaTime * speedRunning;
            transform.position = Vector3.SlerpUnclamped(start, finis, time);
            yield return new WaitForEndOfFrame();
        }

    }

    private IEnumerator runningBackRoutineCoroutine(Vector3 start, Vector3 finis)
    {
        float time = 0.0f;
        while (true)
        {
            time += Time.deltaTime * speedRunning;
            transform.position = Vector3.SlerpUnclamped(finis, start, time);
            yield return new WaitForEndOfFrame();
        }

    }
    void Start()
    {
        if (First != null && Finish != null)
        {
            runningRoutine = StartCoroutine(runningRoutineCoroutine(First.position, Finish.position));
        }    
    }

    void Update()
    {
        if(First != null && Finish != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (runningRoutine != null)
                {
                    StopCoroutine(runningRoutine);
                    runningRoutine = null;
                    runningBackRoutine = StartCoroutine(runningBackRoutineCoroutine(First.position, Finish.position));
                }

                else
                {
                    StopCoroutine(runningBackRoutine);
                    runningBackRoutine = null;
                    runningRoutine = StartCoroutine(runningRoutineCoroutine(First.position, Finish.position));
                }   
                       
            }
        }
    }
}
