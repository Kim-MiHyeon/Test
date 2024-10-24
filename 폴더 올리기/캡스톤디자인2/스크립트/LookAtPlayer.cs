using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;  // �÷��̾��� Transform�� ����

    void Update()
    {
        if (player != null)
        {
            // ��ư�� �÷��̾ ���ϵ��� ȸ��
            transform.LookAt(player);

            // ȸ���� �����Ͽ� ��ư�� �������� �ʵ��� ��
            transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        }
    }
}
