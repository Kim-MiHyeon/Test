using System.Collections;
using UnityEngine;

public class toggle_move_2d : MonoBehaviour
{
    public RectTransform targetObject;   // 이동할 2D UI 오브젝트 (RectTransform)
    public Vector2 positionA;            // A 위치 (X, Y 좌표)
    public Vector2 positionB;            // B 위치 (X, Y 좌표)
    public float moveDuration = 1f;      // 이동 시간

    private bool isAtPositionA = true;   // 현재 위치가 A인지 여부

    // OnClick 이벤트에 연결할 메서드
    public void OnButtonClick()
    {
        // 현재 위치에 따라 A → B 또는 B → A로 이동
        Vector2 targetPosition = isAtPositionA ? positionB : positionA;
        StartCoroutine(MoveObject(targetPosition));

        // 위치 상태 반전
        isAtPositionA = !isAtPositionA;
    }

    // 오브젝트를 지정한 위치로 이동시키는 코루틴
    private IEnumerator MoveObject(Vector2 targetPosition)
    {
        Vector2 startPosition = targetObject.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            targetObject.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 최종 위치 설정
        targetObject.anchoredPosition = targetPosition;
    }
}
