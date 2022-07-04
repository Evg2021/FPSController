using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSLerpMoveCorutine : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float moveSpeed = 0.2f;
    private Coroutine spheraRoutine;
    private List<Vector3> positions;

    private IEnumerator SphereCoroutine(Vector3 start, Vector3 end)
    {
        float time = 0.0f;
        positions = new List<Vector3>();
        positions.Add(transform.position);
        while (true)
        {
            time += Time.deltaTime * moveSpeed;
            transform.position = Vector3.SlerpUnclamped(start, end, time);
            positions.Add(transform.position);
            yield return new WaitForEndOfFrame();
        }
    }
    // Start is called before the first frame update
    void Start()
    {        
        if (startPosition != null && endPosition != null)
        {
            
            spheraRoutine = StartCoroutine(SphereCoroutine(startPosition.position, endPosition.position));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startPosition != null && endPosition != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (spheraRoutine != null)
                {
                    StopCoroutine(spheraRoutine);
                    spheraRoutine = null;
                }
                spheraRoutine = StartCoroutine(SphereCoroutine(startPosition.position, endPosition.position));
                                
            }
        }        
    }
    private void OnDrawGizmos()
    {
        if(positions != null && positions.Count>2)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i< positions.Count - 1; i++)
            {
                
                Gizmos.DrawLine(positions[i], positions[i + 1]);
            }
        }
    }
}
