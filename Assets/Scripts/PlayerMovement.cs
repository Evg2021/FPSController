using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Первая реализация
    public float moveSpeed = 10f; // скорость движения вперед
    public float rotateSpeed = 10f; // скорость поворота вокруг оси Y

    public Vector3 offsetBack;
    public Vector3 deltaBack;    

    private Vector3 forw; //  переменная вектор движения вперед

    private float vInput; // переменная для хранения координат перемещения вперед WS
    private float hInput; // переменная для хранения координат поворота вокруг AD

    private bool isStoped = false;
    private bool isMoved = false;
    private Coroutine currentRoutine;

    public float speed = 1;
    
    public float Min;
    public float Max;
    [Range(0, 1)]
    public float t = 0;
    public float current;

    public float currentTime;
    public float deltaTime;

    public Transform startPos;
    public Transform semyPos;
    public Transform finishPos;

    private float startTime;
    private float journeyLength;


    private void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos.position, finishPos.position);
        //StartCoroutine(MoveBack());
    }

    private IEnumerator MoveBack(Vector3 startPosition, Vector3 endPosition)
    {
        float time = 0.0f;

        while (time < 1)
        {
            time += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return new WaitForEndOfFrame();
        }
        currentRoutine = null;
    }

    private void OnValidate()
    {
        current = Mathf.Lerp(Min, Max, t);
    }

    public void Update()
    {

        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(Vector3.Lerp(startPos.position, semyPos.position, fractionOfJourney), finishPos.position, fractionOfJourney);

        //Первая реализация

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        // реализация движения вперед
        forw = transform.forward * vInput;
        transform.position = forw * Time.deltaTime + transform.position;

        // реализация поворота вокруг оси Y

        transform.eulerAngles += new Vector3(0.0f, hInput, 0.0f) * Time.deltaTime;

        // релизация откатывания назад после остановки движения
        if ((int)vInput == 0 && (int)hInput == 0 && isMoved)
        {
            isStoped = true;
        }
        else if ((int)vInput != 0 || (int)hInput != 0)
        {
            isMoved = true;
            isStoped = false;
            if (currentRoutine != null)
            {
                StopCoroutine(currentRoutine);
                currentRoutine = null;
            }
        }

        if (isStoped && isMoved) // реализуем откат в корутине
        {
            if (currentRoutine == null)
            {
                currentRoutine = StartCoroutine(MoveBack(transform.position, transform.position + offsetBack));
            }
            isMoved = false;
        }

        currentTime += Time.deltaTime;
        deltaTime = Time.deltaTime;
    }
    
}
