using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    public abstract void MoveTowards(Vector3 targetPosition, float speed);
}
