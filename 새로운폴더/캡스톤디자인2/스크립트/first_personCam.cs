using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class first_personCam : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 회전 속도    
    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 (카메라 위 아래 방향)

    public GraphicRaycaster raycaster; // Canvas의 GraphicRaycaster 참조
    public EventSystem eventSystem;   //  EventSystem 참조

    // Start is called before the first frame update
    // void Start()
    // {
    //     Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서를 화면 중앙에 고정
    //     // Cursor.visible = false;                    // 마우스 커서 숨김
    // }

    // Update is called once per frame
    void Update()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        //  카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        // UI 버튼 클릭 처리
        // if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭 감지
        // {
        //     PointerEventData pointerEventData = new PointerEventData(eventSystem);
        //     pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2); // 화면 중앙 좌표

        //     List<RaycastResult> results = new List<RaycastResult>();
        //     raycaster.Raycast(pointerEventData, results);

        //     foreach (RaycastResult result in results)
        //     {
        //         Button button = result.gameObject.GetComponent<Button>();
        //         if (button != null)
        //         {
        //             button.onClick.Invoke();
        //         }
        //     }
        // }
    }
}
