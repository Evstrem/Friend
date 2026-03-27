using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PetAnimationController : MonoBehaviour
{
    public Animator animator;
    public float walkThreshold = 0.01f;

    private Rigidbody rb;
    private Vector3 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = rb.position;
    }

    void FixedUpdate()
    {
        float moveAmount = Vector3.Distance(rb.position, lastPosition);
        bool isMoving = moveAmount > walkThreshold;

        animator.SetBool("isWalking", isMoving);

        lastPosition = rb.position;
    }
}