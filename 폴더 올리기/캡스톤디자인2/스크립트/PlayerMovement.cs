using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float jumpForce = 5f; // ���� ��
    public float gravityScale = 2f; // �߷� ������

    private CharacterController controller; // ĳ���� ��Ʈ�ѷ�
    private Vector3 moveDirection; // �̵� ����
    private Camera mainCamera; // ���� ī�޶�

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

        // ī�޶��� ���� �������� �̵� ���� ����
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        // Y�� ���� ���� (���� ���⸸ ���)
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // �̵� ���� ���
        Vector3 desiredMoveDirection = (forward * moveZ + right * moveX).normalized * moveSpeed;

        // �߷� ����
        if (controller.isGrounded)
        {
            if (moveDirection.y < 0)
            {
                moveDirection.y = -2f; // ���鿡 ���� �� Y�� �ӵ� �ʱ�ȭ (�ణ�� �ϰ� �ӵ� ����)
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime; // �߷� ����
        }

        moveDirection.x = desiredMoveDirection.x;
        moveDirection.z = desiredMoveDirection.z;

        // �̵� ����
        controller.Move(moveDirection * Time.deltaTime);
    }
}
