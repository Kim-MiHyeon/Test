using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints; // 차량이 따라갈 경로 포인트들
    public float speed = 5f; // 차량 속도
    public float rotationSpeed = 5f; // 차량 회전 속도
    public float reachDistance = 1f; // 포인트에 도달했다고 판단하는 거리
    public float stopDistance = 3f; // 차량이 멈출 기준 거리

    // 다른 차량 오브젝트를 배열로 할당
    public GameObject[] otherCars; // 감지할 다른 차량들

    private int currentWaypoint = 0; // 현재 목표로 하는 경로 포인트 인덱스
    private Vector3 initialPosition; // 차량의 초기 위치
    private Quaternion initialRotation; // 차량의 초기 회전
    private bool isStopped = false; // 차량이 멈췄는지 여부

    void Start()
    {
        // 차량의 초기 위치와 회전 저장
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (waypoints.Length == 0 || otherCars.Length == 0) return;

        // 가장 가까운 차량과의 거리 계산
        bool isCarInFront = false;
        foreach (GameObject otherCar in otherCars)
        {
            if (otherCar != null && otherCar != gameObject) // 자신을 제외한 다른 차량만 체크
            {
                // 차량과의 거리 계산
                float distanceToOtherCar = Vector3.Distance(transform.position, otherCar.transform.position);

                // 차량의 앞쪽에 있는지 확인
                Vector3 directionToOtherCar = (otherCar.transform.position - transform.position).normalized;
                float dotProduct = Vector3.Dot(transform.forward, directionToOtherCar);

                // 앞쪽에 있고 거리 안에 있으면 멈춤
                if (dotProduct > 0.5f && distanceToOtherCar < stopDistance) // 앞쪽에 있고 거리 안에 있으면
                {
                    isCarInFront = true;
                    break; // 앞쪽에 차량이 있으면 더 이상 확인하지 않음
                }
            }
        }

        // 앞쪽에 차량이 있으면 멈춤
        if (isCarInFront)
        {
            isStopped = true;
        }
        else
        {
            isStopped = false;
        }

        // 멈춘 상태라면 아래 코드를 실행하지 않음
        if (isStopped) return;

        // 현재 목표로 하는 경로 포인트
        Transform targetWaypoint = waypoints[currentWaypoint];

        // 차량이 현재 목표 포인트로 이동
        Vector3 direction = targetWaypoint.position - transform.position;
        direction.y = 0; // 수평 방향만 고려
        Vector3 moveDirection = direction.normalized * speed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);

        // 차량을 목표 포인트 방향으로 회전

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // 차량이 목표 포인트에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetWaypoint.position) < reachDistance)
        {
            //  다음 경로 포인트로 이동

            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                // 모든 포인트를 방문했으면 처음 위치로 이동하고 초기화
                transform.position = initialPosition;
                transform.rotation = initialRotation;
                currentWaypoint = 0;
            }
        }
    }

    // Gizmos를 사용하여 감지 반경을 시각적으로 확인 (씬 뷰에서 보임)

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
