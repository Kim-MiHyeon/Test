using UnityEngine;

public class stop_taxi : MonoBehaviour
{
    public Transform targetObject; // ��������� ���� ��� ������Ʈ (��: Ʈ���� ������Ʈ)
    public float stopDistance = 5f; // ��Ȱ��ȭ�� �Ÿ�
    public MonoBehaviour scriptToDisable; // ��Ȱ��ȭ�� ��ũ��Ʈ (Inspector���� ����)

    private bool isDisabled = false; // ��ũ��Ʈ�� ��Ȱ��ȭ�Ǿ����� Ȯ���ϴ� ����

    void Update()
    {
        // �ڵ����� ��ǥ ������Ʈ ������ �Ÿ� ���
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);

        // ��ǥ ������Ʈ�� ��������� ��ũ��Ʈ�� ��Ȱ��ȭ
        if (distanceToTarget < stopDistance && !isDisabled && scriptToDisable != null)
        {
            scriptToDisable.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
            isDisabled = true; // ��Ȱ��ȭ ���·� ��ȯ
        }
        // ��ǥ ������Ʈ���� �Ÿ��� �־����� ��ũ��Ʈ�� �ٽ� Ȱ��ȭ
        else if (distanceToTarget >= stopDistance && isDisabled && scriptToDisable != null)
        {
            scriptToDisable.enabled = true; // ��ũ��Ʈ Ȱ��ȭ
            isDisabled = false; // Ȱ��ȭ ���·� ��ȯ
        }
    }
}
