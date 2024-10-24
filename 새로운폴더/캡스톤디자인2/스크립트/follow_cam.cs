using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_cam : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상
    public Vector3 offset ; // 대상과의 오프셋 (거리, 높이 등)

    void Update()
    {
        // 대상의 위치에 오프셋을 더해 카메라의 위치를 설정
        transform.position = target.position + offset;
    }
}
