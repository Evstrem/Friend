using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PetWander : MonoBehaviour
{
    public Transform roomCenter;
    public PetStats petStats;

    [Header("Movement")]
    public float moveSpeed = 1.2f;
    public float rotationSpeed = 3f;
    public float stopDistance = 0.2f;

    [Header("Waiting")]
    public float minWaitTime = 2.5f;
    public float maxWaitTime = 5f;

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
        targetPosition = rb.position;
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

        targetPosition = new Vector3(randomX, rb.position.y, randomZ);
    }

    void MoveToTarget()
    {
        Vector3 direction = targetPosition - rb.position;
        direction.y = 0f;

        float distanceToTarget = direction.magnitude;

        if (distanceToTarget <= stopDistance)
        {
            isWaiting = true;
            SetNewWaitTime();
            return;
        }

        Vector3 moveDirection = direction.normalized;

        float speedFactor = Mathf.Clamp01(distanceToTarget);
        Vector3 nextPosition = rb.position + moveDirection * moveSpeed * speedFactor * Time.fixedDeltaTime;

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