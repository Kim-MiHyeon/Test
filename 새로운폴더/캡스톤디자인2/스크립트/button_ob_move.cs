using System.Collections;
using UnityEngine;

public class button_ob_move : MonoBehaviour
{
    public Transform targetObject;        // ������ ������Ʈ

    public Vector3 initialPosition;       // �ʱ� ��ġ
    public Vector3 initialRotation;       // �ʱ� ����
    public Vector3 initialScale;          // �ʱ� ũ��

    public Vector3 targetPosition;        // ��ǥ ��ġ
    public Vector3 targetRotation;        // ��ǥ ����
    public Vector3 targetScale;           // ��ǥ ũ��

    public float transitionDuration = 1f; // Ʈ������ ���� �ð�
    public float delayTime = 0f;          // �ൿ ���� �� ������ �ð�

    private bool hasTriggered = false;    // ��ư�� ���ȴ��� ����

    private void Start()
    {
        // ������Ʈ�� �ʱ� ��ġ, ����, ũ��� ����
        targetObject.position = initialPosition;
        targetObject.rotation = Quaternion.Euler(initialRotation);
        targetObject.localScale = initialScale;
    }

    // OnClick �̺�Ʈ���� ������ �޼���
    public void OnButtonClick()
    {
        if (!hasTriggered) // �̹� �� �� ���ȴ��� Ȯ��
        {
            Debug.Log("Button clicked");
            hasTriggered = true;
            StartCoroutine(DelayedAnimation());
        }
    }

    // ������ �ð� �Ŀ� �ִϸ��̼� ����
    private IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(delayTime);  // ������ ������ �ð���ŭ ���
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
