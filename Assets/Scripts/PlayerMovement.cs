using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 10f; // �������� �������� ������
    public float rotateSpeed = 10f; // �������� �������� ������ ��� Y

    public Vector3 offsetBack;
    public Vector3 deltaBack;

    private Vector3 forw; //  ���������� ������ �������� ������

    private float vInput; // ���������� ��� �������� ��������� ����������� ������ WS
    private float hInput; // ���������� ��� �������� ��������� �������� ������ AD

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

    //private float startTime;
    //private float journeyLength;

    public bool getKeyUp;
    public bool getKeyDown;
    public bool getKeyKey;

    private void Start()
    {
        //startTime = Time.time;
        //journeyLength = Vector3.Distance(startPos.position, finishPos.position);
        StartCoroutine(MoveBack(startPos.position, finishPos.position));
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
    private IEnumerator MoveBack(Vector3 startPosition, Vector3 midPosition, Vector3 endPosition)
    {
        float time = 0.0f;

        while (time < 1)
        {
            time += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(Vector3.Lerp(startPosition, midPosition, time), Vector3.Lerp(midPosition, endPosition, time), time);
            yield return new WaitForEndOfFrame();
        }
        currentRoutine = null;
    }

    private void OnValidate()
    {
        current = Mathf.Lerp(Min, Max, t);

        CharacterController s = GetComponent<CharacterController>();

        if (s != null)
        {
            s.stepOffset = t;
        }

        var b = startPos.GetComponent<BoxCollider>();
        if( b != null)
        {
            b.center = new Vector3(0, t, 0);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(MoveBack(startPos.position, semyPos.position, finishPos.position));
        }
        //Move();

        getKeyUp = Input.GetKeyUp(KeyCode.H);
        getKeyDown = Input.GetKeyDown(KeyCode.H); 
        getKeyKey = Input.GetKey(KeyCode.H);

        if (getKeyDown)
        {
            t += 0.05f;
        }

    }
    private void Move()
    {
        //������ ����������

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        // ���������� �������� ������
        forw = transform.forward * vInput;
        transform.position = forw * Time.deltaTime + transform.position;

        // ���������� �������� ������ ��� Y

        transform.eulerAngles += new Vector3(0.0f, hInput, 0.0f) * Time.deltaTime;

        // ��������� ����������� ����� ����� ��������� ��������
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

        if (isStoped && isMoved) // ��������� ����� � ��������
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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (startPos)
        {
            Gizmos.DrawSphere(startPos.position, 1);
        }

        if (semyPos)
        {
            Gizmos.DrawSphere(semyPos.position, 1);

        }

        if (finishPos)
        {
            Gizmos.DrawSphere(finishPos.position, 1);

        }
    }
}
