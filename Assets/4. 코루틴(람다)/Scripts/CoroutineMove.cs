using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMove : MonoBehaviour
{
    IEnumerator RotateCoroutine()
    {
        float endTime = Time.time + 5;

        while(Time.time < endTime)
        {
            transform.Rotate(new Vector3(60, 0, 0) * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator MoveCoroutine()
    {
        float endTime = Time.time + 5;

        while(Time.time < endTime)
        {
            transform.Translate(new Vector3(0, .1f, 0) * Time.deltaTime);
            yield return null;
        }
    }

    Coroutine mainCoroutine;
    Coroutine rotateCoroutine;
    Coroutine moveCoroutine;

    IEnumerator MainCoroutine()
    {
        while(true)
        {
            moveCoroutine = StartCoroutine(MoveCoroutine());
            yield return moveCoroutine;
            rotateCoroutine = StartCoroutine(RotateCoroutine());
            yield return rotateCoroutine;
            // return���� �ڷ�ƾ�� ������(StartCoroutine(MoveCoroutine())) �ش� �ڷ�ƾ�� ���� ������ ��ٸ�
        }
    }


    private void Start()
    {
        mainCoroutine = StartCoroutine(MainCoroutine());

    }

    public void CoroutineStopButton()
    {
        if(mainCoroutine != null) StopCoroutine(mainCoroutine);
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        if(rotateCoroutine != null) StopCoroutine(rotateCoroutine);
    }
}
