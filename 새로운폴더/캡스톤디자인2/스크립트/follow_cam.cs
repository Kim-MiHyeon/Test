using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_cam : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ���
    public Vector3 offset ; // ������ ������ (�Ÿ�, ���� ��)

    void Update()
    {
        // ����� ��ġ�� �������� ���� ī�޶��� ��ġ�� ����
        transform.position = target.position + offset;
    }
}
