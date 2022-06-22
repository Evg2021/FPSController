using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContest : MonoBehaviour
{
    public List<Transform> Positions;
    public float SpeedOfMoving;
    public bool getKeyDown;
    public int GlobalIndex;
    private Camera newCamera;
    private float minFOV = 30.0f;
    private float maxFOV = 60.0f;
    private Coroutine cameraRoutina;
    





    private IEnumerator MoveCamera (Transform moveA, Transform moveB)
    {
        float time = 0.0f;
        var startPosition = newCamera.transform.position;
        var startRotation = newCamera.transform.rotation;
        while (time < 1)
        {
            time += Time.deltaTime * SpeedOfMoving;
            newCamera.transform.position = Vector3.Lerp(startPosition, moveB.position, time);
            newCamera.fieldOfView = Mathf.Lerp(minFOV, maxFOV, time);
            newCamera.transform.rotation = Quaternion.Lerp(startRotation, moveB.rotation, time);
            yield return new WaitForEndOfFrame();
        }
        cameraRoutina = null;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        newCamera = FindObjectOfType<Camera>();
        if (newCamera != null)
        {
            if(Positions != null && Positions.Count > 0)
            {
                newCamera.transform.position = Positions[0].position;

                GlobalIndex = 0;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newCamera != null && Positions != null)
        {        
            getKeyDown = Input.GetKeyDown(KeyCode.Space);

            if (getKeyDown)
            {
                if (GlobalIndex < Positions.Count-1)
                {
                    GlobalIndex++;
                    if (cameraRoutina != null)
                    {
                        StopCoroutine(cameraRoutina);
                        cameraRoutina = null;
                    }

                    cameraRoutina = StartCoroutine(MoveCamera(Positions[GlobalIndex - 1], Positions[GlobalIndex]));

                }
            }
            
        }
    }
}
