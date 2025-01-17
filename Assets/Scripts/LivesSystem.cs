using Unity.Mathematics;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    [SerializeField] private float lives;

    public float Lives { get => lives; set => lives = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void receiveDamage(float damageDealt){
        lives -= damageDealt;
        if(lives<=0){
            Destroy(this.gameObject);
        }
    }
    
}
