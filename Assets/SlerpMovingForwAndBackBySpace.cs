using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpMovingForwAndBackBySpace : MonoBehaviour
{
    public Transform First;
    public Transform Finish;
    public float speedRunning = 0.2f;
    private Coroutine runningRoutine;
    private Coroutine runningBackRoutine;
    private List<Vector3> positions;
    public float time = 0.0f;

    private IEnumerator runningRoutineCoroutine(Vector3 start, Vector3 finish)
    {
        //float time = 0.0f;
        positions = new List<Vector3>();
        positions.Add(transform.position);
        while (true)
        {
            time += Time.deltaTime * speedRunning;            
            transform.position = Vector3.SlerpUnclamped(start, finish, time);
            positions.Add(transform.position);
            yield return new WaitForEndOfFrame();
        }

    }

    private IEnumerator runningBackRoutineCoroutine(Vector3 start, Vector3 finish)
    {
        //float time = 0.0f;
        positions = new List<Vector3>();
        positions.Add(transform.position);
        while (true)
        {
            time -= Time.deltaTime * speedRunning;
            transform.position = Vector3.SlerpUnclamped(start, finish, time);
            positions.Add(transform.position);
            yield return new WaitForEndOfFrame();
        }

    }
    void Start()
    {
        time = 0.0f;
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

                else if (runningBackRoutine != null)
                {
                    StopCoroutine(runningBackRoutine);
                    runningBackRoutine = null;
                    runningRoutine = StartCoroutine(runningRoutineCoroutine(First.position, Finish.position));
                }   
                       
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (positions != null && positions.Count > 2)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < positions.Count - 1; i++)
            {

                Gizmos.DrawLine(positions[i], positions[i + 1]);
            }
        }
    }
}
