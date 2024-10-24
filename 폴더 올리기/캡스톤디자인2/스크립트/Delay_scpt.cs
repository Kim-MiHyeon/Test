using UnityEngine;

public class Delay_scpt : MonoBehaviour
{
    public MonoBehaviour targetScript;  // Ȱ��ȭ/��Ȱ��ȭ�� ��ũ��Ʈ(������Ʈ)
    public float delayTime = 2.0f;      // �� �� �Ŀ� �������� ����
    public bool activate = true;        // true�̸� Ȱ��ȭ, false�̸� ��Ȱ��ȭ

    // OnClick �̺�Ʈ���� ������ �޼���
    public void OnButtonClick()
    {
        // ��ư Ŭ�� �� delayTime �Ŀ� ActivateScript �޼��� ����
        Invoke("ActivateScript", delayTime);
    }

    void ActivateScript()
    {
        // ��ũ��Ʈ Ȱ��ȭ/��Ȱ��ȭ
        if (targetScript != null)
        {
            targetScript.enabled = activate;
        }
    }
}
