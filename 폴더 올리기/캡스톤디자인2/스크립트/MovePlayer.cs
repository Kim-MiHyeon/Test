using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;  // �÷��̾� ������Ʈ
    public Vector3 targetPosition;  // �̵��� ��ǥ ��ġ

    // ��ư Ŭ�� �� ȣ��� �޼ҵ�
    public void MoveToTargetPosition()
    {
        if (player != null)
        {
            player.transform.position = targetPosition;
        }
    }
}
