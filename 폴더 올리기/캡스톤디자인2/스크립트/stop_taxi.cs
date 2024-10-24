using UnityEngine;

public class stop_taxi : MonoBehaviour
{
    public Transform targetObject; // 가까워졌을 때의 대상 오브젝트 (예: 트리거 오브젝트)
    public float stopDistance = 5f; // 비활성화할 거리
    public MonoBehaviour scriptToDisable; // 비활성화할 스크립트 (Inspector에서 설정)

    private bool isDisabled = false; // 스크립트가 비활성화되었는지 확인하는 변수

    void Update()
    {
        // 자동차와 목표 오브젝트 사이의 거리 계산
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);

        // 목표 오브젝트에 가까워지면 스크립트를 비활성화
        if (distanceToTarget < stopDistance && !isDisabled && scriptToDisable != null)
        {
            scriptToDisable.enabled = false; // 스크립트 비활성화
            isDisabled = true; // 비활성화 상태로 전환
        }
        // 목표 오브젝트와의 거리가 멀어지면 스크립트를 다시 활성화
        else if (distanceToTarget >= stopDistance && isDisabled && scriptToDisable != null)
        {
            scriptToDisable.enabled = true; // 스크립트 활성화
            isDisabled = false; // 활성화 상태로 전환
        }
    }
}
