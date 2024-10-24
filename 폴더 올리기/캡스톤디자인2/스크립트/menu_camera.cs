using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class menu_camera : MonoBehaviour
{
    public float turnSpeed = 1f; // 마우스 회전 속도    
    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 (카메라 위 아래 방향)
    private float yRotate = 0.0f;

    private Vector3 initialRotation;


    void Start()
    {
        // 초기 회전 각도 저장
        initialRotation = transform.eulerAngles;
        xRotate = initialRotation.x;
        yRotate = initialRotation.y;
    }
    // Update is called once per frame
    void Update()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도
        // float yRotate = transform.eulerAngles.y + yRotateSize;
        yRotate = Mathf.Clamp(yRotate + yRotateSize, -5, 5);

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -5, 5);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(initialRotation.x + xRotate, initialRotation.y + yRotate, 0);
        // transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

    }
}
