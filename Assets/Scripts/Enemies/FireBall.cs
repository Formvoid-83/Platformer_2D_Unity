using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D rb;
    private float timer;
    [SerializeField] private float damage;
    [SerializeField] private float shotForce;
    [SerializeField] private float durationTime;
    private Animator anim;
    private CircleCollider2D collider;
    private Vector2 direction;
    private bool isExploding = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * shotForce, ForceMode2D.Impulse);
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > durationTime - 0.5f && !isExploding)
        {
            StartCoroutine(DestroyBall());
        }
    }
    IEnumerator DestroyBall()
    {
        isExploding = true;
        anim.SetTrigger("explotar");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
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
    public void Explotion(){
        collider.radius = 0.9f;
    }
}
