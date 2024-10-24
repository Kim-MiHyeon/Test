using System.Collections;
using UnityEngine;

public class button_ob_move : MonoBehaviour
{
    public Transform targetObject;        // 변경할 오브젝트

    public Vector3 initialPosition;       // 초기 위치
    public Vector3 initialRotation;       // 초기 각도
    public Vector3 initialScale;          // 초기 크기

    public Vector3 targetPosition;        // 목표 위치
    public Vector3 targetRotation;        // 목표 각도
    public Vector3 targetScale;           // 목표 크기

    public float transitionDuration = 1f; // 트랜지션 지속 시간
    public float delayTime = 0f;          // 행동 실행 전 딜레이 시간

    private bool hasTriggered = false;    // 버튼이 눌렸는지 여부

    private void Start()
    {
        // 오브젝트를 초기 위치, 각도, 크기로 설정
        targetObject.position = initialPosition;
        targetObject.rotation = Quaternion.Euler(initialRotation);
        targetObject.localScale = initialScale;
    }

    // OnClick 이벤트에서 연결할 메서드
    public void OnButtonClick()
    {
        if (!hasTriggered) // 이미 한 번 눌렸는지 확인
        {
            Debug.Log("Button clicked");
            hasTriggered = true;
            StartCoroutine(DelayedAnimation());
        }
    }

    // 딜레이 시간 후에 애니메이션 시작
    private IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(delayTime);  // 설정된 딜레이 시간만큼 대기
        StartCoroutine(AnimateObject(targetPosition, targetRotation, targetScale));
    }

    private IEnumerator AnimateObject(Vector3 endPosition, Vector3 endRotation, Vector3 endScale)
    {
        Vector3 startPosition = targetObject.position;
        Quaternion startRotation = targetObject.rotation;
        Vector3 startScale = targetObject.localScale;

        Quaternion endRotationQuat = Quaternion.Euler(endRotation);

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            targetObject.position = Vector3.Lerp(startPosition, endPosition, t);
            targetObject.rotation = Quaternion.Lerp(startRotation, endRotationQuat, t);
            targetObject.localScale = Vector3.Lerp(startScale, endScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetObject.position = endPosition;
        targetObject.rotation = endRotationQuat;
        targetObject.localScale = endScale;
    }
}
