using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPultSwitcher : MonoBehaviour
{
    public GameObject OnPult;
    public float OnPultRotationSpeed = 3.0f;
    public float OnPultBackRotationSpeed = 2.0f;
    public float OnPultAngleRotation = 30.0f;
    public float time;
    public Quaternion OnPultStartPositionRotation;
    public Quaternion OnPultEndPositionRotation;

    private bool onPultRotationStarted = false;
    private Coroutine onPultRotationRout;

    

    // Start is called before the first frame update
    void Start()
    {
        //time = 0.0f;
        OnPultStartPositionRotation = OnPult.transform.rotation;
        OnPultEndPositionRotation = OnPultStartPositionRotation * Quaternion.Euler(0,0, OnPultAngleRotation);
    }

    // Update is called once per frame
    void Update()
    {
        //if (OnPult != null && onPultRotationStarted)
        //{
        //    time += Time.deltaTime;
        //    if(true)
        //    {
        //        OnPult.transform.rotation = Quaternion.Lerp(OnPultStartPositionRotation,OnPultEndPositionRotation,time);
        //        OnPultAngleRotation += OnPultAngleRotation;
        //        if (OnPultAngleRotation <= 90.0f)
        //        {
        //            onPultRotationStarted = false;
        //            time = 0.0f;
        //        }
                //else if ( time > 1.0f)
                //{
                //    OnPult.transform.rotation = Quaternion.Lerp(OnPultEndPositionRotation, OnPultStartPositionRotation, time - 1);
                //}
                //if (time >= 2.0f)
                //{
                //    onPultRotationStarted = false;
                //    time = 0.0f;
                //}
            //}            
    }
    
    private IEnumerator onPultRotationRoutine(Quaternion Start, Quaternion End)
    {
        float time = 0.0f;
        while (time < 1)
        {
            time += Time.deltaTime * OnPultRotationSpeed;
            OnPult.transform.rotation = Quaternion.LerpUnclamped(Start, End, time);
            yield return new WaitForEndOfFrame();
        }
        time = 0.0f;
        while (time < 1)
        {
            time += Time.deltaTime * OnPultBackRotationSpeed;
            OnPult.transform.rotation = Quaternion.Lerp(End, Start, time);
            yield return new WaitForEndOfFrame();
        }

        onPultRotationRout = null;
    }


    public void OnPultClickStart()
    {
        if (OnPult != null)
        {
            //onPultRotationStarted = true;

            onPultRotationRout = StartCoroutine(onPultRotationRoutine(OnPultStartPositionRotation, OnPultEndPositionRotation));
        }
        
    }
}
