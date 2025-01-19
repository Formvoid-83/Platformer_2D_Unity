using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D rb;
    private float timer;
    [SerializeField] private float damage;
    [SerializeField] private float shotForce;
    private Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * shotForce, ForceMode2D.Impulse);
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>3){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            // Apply damage or any effect on the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage((int)damage);
            }

            // Destroy the fireball after interaction
            Destroy(gameObject);
        }
    }
    public void SetDirection(Vector2 newDirection)
    {
        Debug.Log("HETADFADG");
        direction = newDirection.normalized; // Normalize to ensure consistent speed
        
    }
}
