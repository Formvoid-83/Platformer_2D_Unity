using UnityEngine;

public class AttackState : State<EnemyController>
{
    [SerializeField] private float attackDistance;
    [SerializeField] private float timeBetweenAttacks;
    private float timer;
    private Transform target;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
        target = FindFirstObjectByType<Player>().transform;
        timer= timeBetweenAttacks;
        Debug.Log("ATTACK");
    }

    public override void OnUpdateState()
    {
        timer+= Time.deltaTime;
        if(timer > timeBetweenAttacks){
            //Trigger animation
            timer=0;
        }
        if(Vector3.Distance(transform.position, target.position) > attackDistance){
            controller.changeState(controller.ChaseState);
        }
    }
    public override void OnExitState()
    {
        //throw new System.NotImplementedException();
    }
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.TryGetComponent(out Player player)){
            //target = player.transform;
         }
    }
}
