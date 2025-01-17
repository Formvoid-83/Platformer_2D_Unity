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
        if(target){

        transform.position = Vector3.MoveTowards(transform.position, target.position, chaseVelocity * Time.deltaTime);
        if(Vector3.Distance(transform.position, target.position) <= stopDistance){
            controller.changeState(controller.AttackState);
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
