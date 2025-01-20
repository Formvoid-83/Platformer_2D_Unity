using UnityEngine;

public class FlyingMovement : EnemyMovement
{
    private Animator anim;
    private CircleCollider2D collider;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        collider = gameObject.GetComponent<CircleCollider2D>();
    }
    public override void MoveTowards(Vector3 targetPosition, float speed)
    {
        // Full movement in both X and Y axes
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    public override void AnimateAttack()
    {
        anim.SetTrigger("atacar");
    }
    public override void StopAnimateAttack()
    {
        //anim.SetBool("atacando", false);
    }
    public override void DeathAnimation()
    {
        collider.enabled=false;
        anim.SetTrigger("explosion");
    }
}
