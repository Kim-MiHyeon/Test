using System.Collections;
using UnityEngine;

public class toggle_move_2d : MonoBehaviour
{
    public RectTransform targetObject;   // �̵��� 2D UI ������Ʈ (RectTransform)
    public Vector2 positionA;            // A ��ġ (X, Y ��ǥ)
    public Vector2 positionB;            // B ��ġ (X, Y ��ǥ)
    public float moveDuration = 1f;      // �̵� �ð�

    private bool isAtPositionA = true;   // ���� ��ġ�� A���� ����

    // OnClick �̺�Ʈ�� ������ �޼���
    public void OnButtonClick()
    {
        // ���� ��ġ�� ���� A �� B �Ǵ� B �� A�� �̵�
        Vector2 targetPosition = isAtPositionA ? positionB : positionA;
        StartCoroutine(MoveObject(targetPosition));

        // ��ġ ���� ����
        isAtPositionA = !isAtPositionA;
    }

    // ������Ʈ�� ������ ��ġ�� �̵���Ű�� �ڷ�ƾ
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

        // ���� ��ġ ����
        targetObject.anchoredPosition = targetPosition;
    }
}
