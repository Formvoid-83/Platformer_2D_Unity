using UnityEngine;

public class ChaseState : State<EnemyController>
{
    private Transform target;
    [SerializeField] private float chaseVelocity;
    [SerializeField] private float stopDistance;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
        target = FindFirstObjectByType<Player>().transform;
    }
    public override void OnUpdateState()
{
    if (target)
    {
        controller.MoveTowards(target.position, chaseVelocity);

        if (Vector3.Distance(transform.position, target.position) <= stopDistance)
        {
            controller.changeState(controller.AttackState);
        }
        //Flip the sprite in case the player is to the other side
        if(target.position.x < transform.position.x){
            transform.localScale = new Vector3(-1,1,1);
        }
        else{
            transform.localScale = new Vector3(1,1,1);
        }
        

    }
}

    public override void OnExitState()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.TryGetComponent(out Player player)){
            //target = player.transform;
         }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.TryGetComponent(out Player player)){
            controller.changeState(controller.PatroState);
         }
    }

}
