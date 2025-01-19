using UnityEngine;

public class FlyingMovement : EnemyMovement
{
    public override void MoveTowards(Vector3 targetPosition, float speed)
    {
        // Full movement in both X and Y axes
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
