using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;  // 플레이어 오브젝트
    public Vector3 targetPosition;  // 이동할 목표 위치

    // 버튼 클릭 시 호출될 메소드
    public void MoveToTargetPosition()
    {
        if (player != null)
        {
            player.transform.position = targetPosition;
        }
    }
}
