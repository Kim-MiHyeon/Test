using UnityEngine;

public class Delay_ob : MonoBehaviour
{
    public GameObject targetObject;  // Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ
    public float delayTime = 2.0f;   // �� �� �Ŀ� �������� ����
    public bool activate = true;     // true�̸� Ȱ��ȭ, false�̸� ��Ȱ��ȭ

    // OnClick �̺�Ʈ���� ������ �޼���
    public void OnButtonClick()
    {
        // ��ư Ŭ�� �� delayTime �Ŀ� ActivateObject �޼��� ����
        Invoke("ActivateObject", delayTime);
    }

    void ActivateObject()
    {
        // ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        if (targetObject != null)
        {
            targetObject.SetActive(activate);
        }
    }
}
