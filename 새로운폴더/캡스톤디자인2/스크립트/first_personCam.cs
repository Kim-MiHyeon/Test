using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class first_personCam : MonoBehaviour
{
    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�    
    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� (ī�޶� �� �Ʒ� ����)

    public GraphicRaycaster raycaster; // Canvas�� GraphicRaycaster ����
    public EventSystem eventSystem;   //  EventSystem ����

    // Start is called before the first frame update
    // void Start()
    // {
    //     Cursor.lockState = CursorLockMode.Locked;  // ���콺 Ŀ���� ȭ�� �߾ӿ� ����
    //     // Cursor.visible = false;                    // ���콺 Ŀ�� ����
    // }

    // Update is called once per frame
    void Update()
    {
        // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� ��
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        //  ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        // UI ��ư Ŭ�� ó��
        // if (Input.GetMouseButtonDown(0)) // ���콺 ��Ŭ�� ����
        // {
        //     PointerEventData pointerEventData = new PointerEventData(eventSystem);
        //     pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2); // ȭ�� �߾� ��ǥ

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
