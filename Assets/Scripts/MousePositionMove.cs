using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionMove : MonoBehaviour
{
    public Vector3 MousePosition;
    public float Speed;
    public float rotateSpeed;
    public bool getMouseDown;
    private Coroutine mouseRoutina;
    // Start is called before the first frame update
    private IEnumerator MoveToMouseClick(Transform moveA, Transform moveB)
    {
        float time = 0.0f;
        var startPosition = transform.position;
        var startRotation = transform.rotation;
        while (time < 1)
        {
            time += Time.deltaTime * Speed;
            transform.position = Vector3.Lerp(startPosition, moveB.position, time);
            transform.rotation = Quaternion.Lerp(startRotation, moveB.rotation, time);
            yield return new WaitForEndOfFrame();
        }
        mouseRoutina = null;
    }

    void Start()
    {
       // StartCoroutine(MoveToMouseClick())
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition = Input.mousePosition;
    }
}
