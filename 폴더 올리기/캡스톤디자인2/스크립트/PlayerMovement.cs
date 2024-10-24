using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float jumpForce = 5f; // 점프 힘
    public float gravityScale = 2f; // 중력 스케일

    private CharacterController controller; // 캐릭터 컨트롤러
    private Vector3 moveDirection; // 이동 방향
    private Camera mainCamera; // 메인 카메라

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component is missing on this GameObject.");
        }

        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 카메라의 방향 기준으로 이동 방향 설정
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        // Y축 방향 제거 (수평 방향만 고려)
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // 이동 방향 계산
        Vector3 desiredMoveDirection = (forward * moveZ + right * moveX).normalized * moveSpeed;

        // 중력 적용
        if (controller.isGrounded)
        {
            if (moveDirection.y < 0)
            {
                moveDirection.y = -2f; // 지면에 있을 때 Y축 속도 초기화 (약간의 하강 속도 유지)
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime; // 중력 적용
        }

        moveDirection.x = desiredMoveDirection.x;
        moveDirection.z = desiredMoveDirection.z;

        // 이동 적용
        controller.Move(moveDirection * Time.deltaTime);
    }
}
