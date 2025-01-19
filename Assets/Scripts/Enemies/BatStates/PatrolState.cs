using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State<EnemyController>
{
    [SerializeField] private Transform route;
    [SerializeField] private float patrolVelocity;
    private List<Vector3> pointList = new List<Vector3>();
    private Vector3 currentDestination;
    private int currentDestinationIndex;     
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
        foreach(Transform t in route){
            pointList.Add(t.position);
        }
        currentDestination = pointList[currentDestinationIndex];
    }

    public override void OnUpdateState()
{
    controller.MoveTowards(currentDestination, patrolVelocity);

    if (transform.position == currentDestination)
    {
        CalculateNewDestination();
    }
}


    private void CalculateNewDestination()
    {
        currentDestinationIndex++;
        if(currentDestinationIndex >= pointList.Count){
            currentDestinationIndex =0;
        }
        currentDestination = pointList[currentDestinationIndex];
        focusObjective();
    }
    private void focusObjective(){
        if(currentDestination.x > transform.position.x){
            transform.localScale = Vector3.one;
        }
        else{
            transform.localScale = new Vector3(-1,1,1);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerDetection")){
            Debug.Log("Te cachamos mi buen");
            controller.changeState(controller.ChaseState);
         }
         else if(other.gameObject.TryGetComponent(out Player player)){
            Debug.Log("Te tocamos prro");
         }
    }

    public override void OnExitState()
    {
        pointList.Clear();
        currentDestinationIndex=0;
    }

}
