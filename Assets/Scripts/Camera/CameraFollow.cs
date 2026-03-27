using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    public Transform lookTarget;
    public Vector3 targetOffset = new Vector3(0f, 1.5f, 0f);

    [Header("Rotation")]
    public float mouseSensitivity = 3f;
    public float minVerticalAngle = -20f;
    public float maxVerticalAngle = 60f;

    [Header("Zoom")]
    public float distance = 6f;
    public float minDistance = 2f;
    public float maxDistance = 8f;
    public float zoomSpeed = 2f;

    [Header("Smoothing")]
    public float followSmoothSpeed = 10f;
    public float rotationSmoothSpeed = 10f;

    [Header("Collision")]
    public float collisionRadius = 0.2f;
    public float collisionOffset = 0.2f;
    public LayerMask collisionLayers;

    private float yaw = 0f;
    private float pitch = 20f;
    private float currentDistance;

    void Start()
    {
        currentDistance = distance;

        Vector3 currentRotation = transform.eulerAngles;
        yaw = currentRotation.y;
        pitch = currentRotation.x;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LateUpdate()
    {
        HandleRotation();
        HandleZoom();
        HandleCameraPosition();
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, minVerticalAngle, maxVerticalAngle);
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }
    }

    void HandleCameraPosition()
    {
        Vector3 followPoint = target.position + targetOffset;
        Vector3 lookPoint = lookTarget != null ? lookTarget.position : followPoint;

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredDirection = rotation * new Vector3(0f, 0f, -distance);

        float adjustedDistance = distance;

        RaycastHit hit;
        if (Physics.SphereCast(
            followPoint,
            collisionRadius,
            desiredDirection.normalized,
            out hit,
            distance,
            collisionLayers))
        {
            adjustedDistance = hit.distance - collisionOffset;
            adjustedDistance = Mathf.Clamp(adjustedDistance, minDistance, distance);
        }

        currentDistance = Mathf.Lerp(currentDistance, adjustedDistance, followSmoothSpeed * Time.deltaTime);

        Vector3 desiredPosition = followPoint + rotation * new Vector3(0f, 0f, -currentDistance);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSmoothSpeed * Time.deltaTime);

        Quaternion lookRotation = Quaternion.LookRotation(lookPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSmoothSpeed * Time.deltaTime);
    }
}