using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSLerpMoveCorutine : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float moveSpeed = 10.0f;
    private Coroutine spheraRoutine;

    private IEnumerator SphereCoroutine(Vector3 start, Vector3 end)
    {
        
        float time = 0.0f;
        
        while (time < 1)
        {
            time += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Slerp(start, end, time);
            yield return null;  
        }
        spheraRoutine = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (startPosition != null && endPosition != null)
        {
            StartCoroutine(SphereCoroutine(startPosition.position, endPosition.position));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (spheraRoutine != null)
        //{
        //    StopCoroutine(spheraRoutine);
        //    spheraRoutine = null;
        //}
    }
}
