using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class menu_camera : MonoBehaviour
{
    public float turnSpeed = 1f; // ���콺 ȸ�� �ӵ�    
    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� (ī�޶� �� �Ʒ� ����)
    private float yRotate = 0.0f;

    private Vector3 initialRotation;


    void Start()
    {
        // �ʱ� ȸ�� ���� ����
        initialRotation = transform.eulerAngles;
        xRotate = initialRotation.x;
        yRotate = initialRotation.y;
    }
    // Update is called once per frame
    void Update()
    {
        // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� ��
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������
        // float yRotate = transform.eulerAngles.y + yRotateSize;
        yRotate = Mathf.Clamp(yRotate + yRotateSize, -5, 5);

        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -5, 5);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        transform.eulerAngles = new Vector3(initialRotation.x + xRotate, initialRotation.y + yRotate, 0);
        // transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

    }
}
