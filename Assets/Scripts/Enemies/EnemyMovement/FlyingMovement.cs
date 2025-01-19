using UnityEngine;

public class FlyingMovement : EnemyMovement
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        anim.SetTrigger("explosion");
    }
}
