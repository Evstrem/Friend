using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PetWander : MonoBehaviour
{
    public Transform roomCenter;
    public PetStats petStats;

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;

    [Header("Waiting")]
    public float minWaitTime = 2f;
    public float maxWaitTime = 4f;

    [Header("Room Bounds")]
    public float moveRangeX = 4f;
    public float moveRangeZ = 4f;
    public float wallPadding = 0.5f;

    [Header("Fatigue")]
    public float tiredEnergyThreshold = 20f;

    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool isWaiting = true;
    private float waitTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
        SetNewWaitTime();
    }

    void FixedUpdate()
    {
        if (petStats.energy <= tiredEnergyThreshold)
            return;

        if (isWaiting)
        {
            waitTimer -= Time.fixedDeltaTime;

            if (waitTimer <= 0f)
            {
                ChooseNewTarget();
                isWaiting = false;
            }

            return;
        }

        MoveToTarget();
    }

    void ChooseNewTarget()
    {
        Vector3 center = roomCenter.position;

        float minX = center.x - moveRangeX + wallPadding;
        float maxX = center.x + moveRangeX - wallPadding;
        float minZ = center.z - moveRangeZ + wallPadding;
        float maxZ = center.z + moveRangeZ - wallPadding;

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    void MoveToTarget()
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f;

        if (direction.magnitude < 0.15f)
        {
            isWaiting = true;
            SetNewWaitTime();
            return;
        }

        Vector3 moveDirection = direction.normalized;
        Vector3 nextPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        Vector3 center = roomCenter.position;
        float minX = center.x - moveRangeX + wallPadding;
        float maxX = center.x + moveRangeX - wallPadding;
        float minZ = center.z - moveRangeZ + wallPadding;
        float maxZ = center.z + moveRangeZ - wallPadding;

        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        nextPosition.z = Mathf.Clamp(nextPosition.z, minZ, maxZ);
        nextPosition.y = rb.position.y;

        rb.MovePosition(nextPosition);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(newRotation);
        }
    }

    void SetNewWaitTime()
    {
        waitTimer = Random.Range(minWaitTime, maxWaitTime);
    }
}