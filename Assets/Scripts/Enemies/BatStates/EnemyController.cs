using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float damage;
    private PatrolState patroState;
    private ChaseState chaseState;
    private AttackState attackState;
    private State<EnemyController> currentState;
    private static float counter;
    public PatrolState PatroState { get => patroState;  }
    public ChaseState ChaseState { get => chaseState;  }
    public AttackState AttackState { get => attackState; }
    public static float Counter { get => counter; set => counter = value; }
    public float Damage { get => damage;}

    void Start()
    {
        patroState = GetComponent<PatrolState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();

        changeState(patroState);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState){
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
}
