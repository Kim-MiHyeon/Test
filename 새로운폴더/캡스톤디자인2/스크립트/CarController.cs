using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints; // ������ ���� ��� ����Ʈ��
    public float speed = 5f; // ���� �ӵ�
    public float rotationSpeed = 5f; // ���� ȸ�� �ӵ�
    public float reachDistance = 1f; // ����Ʈ�� �����ߴٰ� �Ǵ��ϴ� �Ÿ�
    public float stopDistance = 3f; // ������ ���� ���� �Ÿ�

    // �ٸ� ���� ������Ʈ�� �迭�� �Ҵ�
    public GameObject[] otherCars; // ������ �ٸ� ������

    private int currentWaypoint = 0; // ���� ��ǥ�� �ϴ� ��� ����Ʈ �ε���
    private Vector3 initialPosition; // ������ �ʱ� ��ġ
    private Quaternion initialRotation; // ������ �ʱ� ȸ��
    private bool isStopped = false; // ������ ������� ����

    void Start()
    {
        // ������ �ʱ� ��ġ�� ȸ�� ����
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (waypoints.Length == 0 || otherCars.Length == 0) return;

        // ���� ����� �������� �Ÿ� ���
        bool isCarInFront = false;
        foreach (GameObject otherCar in otherCars)
        {
            if (otherCar != null && otherCar != gameObject) // �ڽ��� ������ �ٸ� ������ üũ
            {
                // �������� �Ÿ� ���
                float distanceToOtherCar = Vector3.Distance(transform.position, otherCar.transform.position);

                // ������ ���ʿ� �ִ��� Ȯ��
                Vector3 directionToOtherCar = (otherCar.transform.position - transform.position).normalized;
                float dotProduct = Vector3.Dot(transform.forward, directionToOtherCar);

                // ���ʿ� �ְ� �Ÿ� �ȿ� ������ ����
                if (dotProduct > 0.5f && distanceToOtherCar < stopDistance) // ���ʿ� �ְ� �Ÿ� �ȿ� ������
                {
                    isCarInFront = true;
                    break; // ���ʿ� ������ ������ �� �̻� Ȯ������ ����
                }
            }
        }

        // ���ʿ� ������ ������ ����
        if (isCarInFront)
        {
            isStopped = true;
        }
        else
        {
            isStopped = false;
        }

        // ���� ���¶�� �Ʒ� �ڵ带 �������� ����
        if (isStopped) return;

        // ���� ��ǥ�� �ϴ� ��� ����Ʈ
        Transform targetWaypoint = waypoints[currentWaypoint];

        // ������ ���� ��ǥ ����Ʈ�� �̵�
        Vector3 direction = targetWaypoint.position - transform.position;
        direction.y = 0; // ���� ���⸸ ���
        Vector3 moveDirection = direction.normalized * speed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);

        // ������ ��ǥ ����Ʈ �������� ȸ��

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // ������ ��ǥ ����Ʈ�� �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetWaypoint.position) < reachDistance)
        {
            //  ���� ��� ����Ʈ�� �̵�

            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                // ��� ����Ʈ�� �湮������ ó�� ��ġ�� �̵��ϰ� �ʱ�ȭ
                transform.position = initialPosition;
                transform.rotation = initialRotation;
                currentWaypoint = 0;
            }
        }
    }

    // Gizmos�� ����Ͽ� ���� �ݰ��� �ð������� Ȯ�� (�� �信�� ����)

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
