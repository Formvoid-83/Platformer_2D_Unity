using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;

    protected float Damage { get => damage; set => damage = value; }

    void Start()
    {
        
    }
    protected abstract void Atttack();
}
