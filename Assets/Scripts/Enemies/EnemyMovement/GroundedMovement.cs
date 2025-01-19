using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GroundedMovement : EnemyMovement
{
    [SerializeField] private float groundCheckDistance = 2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float fallSpeed = 5f;

    private Animator anim;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public override void MoveTowards(Vector3 targetPosition, float speed)
    {
        // Move horizontally towards the target
        Vector3 horizontalTarget = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, horizontalTarget, speed * Time.deltaTime);

        // Check for ground below
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance, groundLayer))
        {
            // Align the slime with the ground
            Vector3 groundedPosition = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, groundedPosition, fallSpeed * Time.deltaTime);
        }
        else
        {
            // No ground detected, simulate falling
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }
    public override void AnimateAttack()
    {
        anim.SetBool("atacando", true);
    }
    public override void StopAnimateAttack()
    {
        anim.SetBool("atacando", false);
    }
    public override void DeathAnimation()
    {
        //anim.SetBool("atacando", false);
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the ground detection raycast
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
