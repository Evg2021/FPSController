using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSlerp : MonoBehaviour
{
    [Range(0,1)]
    public float t;
    public Transform starMoveSlerp;
    public Transform finMoveSlerp;
    
    // Start is called before the first frame update

    private void OnValidate()
    {        
        if(starMoveSlerp != null && finMoveSlerp != null)
        {
            var newPosition = Vector3.Slerp(starMoveSlerp.position, finMoveSlerp.position, t);
            var direction = (newPosition - transform.position).normalized;
            transform.position = newPosition;
            transform.forward = direction;

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
