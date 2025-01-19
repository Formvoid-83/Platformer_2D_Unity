using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool isStatic;
    private PatrolState patroState;
    private ChaseState chaseState;
    private AttackState attackState;
    private State<EnemyController> currentState;
    private EnemyMovement movement;
    private static float counter;
    public PatrolState PatroState { get => patroState;  }
    public ChaseState ChaseState { get => chaseState;  }
    public AttackState AttackState { get => attackState; }
    public static float Counter { get => counter; set => counter = value; }
    public float Damage { get => damage;}
    public EnemyMovement Movement { get => movement; set => movement = value; }

    void Start()
    {
        if(!isStatic){
        patroState = GetComponent<PatrolState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();

        movement = GetComponent<EnemyMovement>();

        changeState(patroState);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStatic && currentState){
            currentState.OnUpdateState();
        }
    }
    public void changeState(State<EnemyController> newState){
        if(currentState){
            currentState.OnExitState();
        }
        currentState = newState;
        currentState.OnEnterState(this);
    }
    public void MoveTowards(Vector3 targetPosition, float speed)
    {
        movement.MoveTowards(targetPosition, speed);
        
    }
}
