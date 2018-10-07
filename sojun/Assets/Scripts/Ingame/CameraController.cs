using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTransform;
    //이전 마우스 위치
    public Vector3 oldMousePosition;
    //현재 마우스 위치
    public Vector3 currentMousePosition;
    //최대 시야각 각도
    public float minY, maxY;
    //마우스 감도
    public float speed;
    //x 카운터
    public float xCounter;
    //y 카운터
    public float yCounter;

    public float lerpSpeed = 10f;

    void Update()
    {
        //mouse 0 = 왼쪽 / 1 =오른쪽
        if (Input.GetMouseButtonDown(0))
        {
            oldMousePosition = currentMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            currentMousePosition = Input.mousePosition;

            //움직임 체크
            if (currentMousePosition != oldMousePosition) // 움직임 구분
            {
                //움직이는 로직을 처리

                //방향을 구해요
                Vector3 dir = currentMousePosition - oldMousePosition;
                //수치를 최대 1로 지정해요.-1~1;
                dir = dir.normalized * speed;

                xCounter += dir.x;
                yCounter += dir.y;

                //clamp() ? >> 최소 ~ 최대 값만큼만 리턴
                yCounter = Mathf.Clamp(yCounter, minY, maxY);

                //
            }
        }

    }

    public void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(-yCounter, xCounter, 0);
    }

    public void ResetPosition()
    {
        transform.position = playerTransform.position;
    }

}
