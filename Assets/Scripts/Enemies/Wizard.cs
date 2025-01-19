using System.Collections;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private GameObject fireBall; //Prefab
    [SerializeField] private Transform spawn; //Prefab
    [SerializeField] private float attackTime; //Prefab
    [SerializeField] private Transform wizardSprite; // Drag the wizard's sprite or parent with the SpriteRenderer
    private bool isFacingRight = true;
    private Animator anim; //Prefab

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(attackRoutine());
    }
    IEnumerator attackRoutine(){
        while(true){
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(attackTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            Transform player = other.transform;
            // Check the player's position relative to the wizard and flip if needed
            if ((player.position.x < transform.position.x && isFacingRight) || 
                (player.position.x > transform.position.x && !isFacingRight))
            {
                Flip();
            }
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = wizardSprite.localScale;
        localScale.x *= -1; // Invert the X scale to flip the sprite
        wizardSprite.localScale = localScale;
    }
    private void LanzarBola()
    {
    // Instantiate the fireball
    GameObject spawnedFireball = Instantiate(fireBall, spawn.position, Quaternion.identity);

    // Determine direction based on isFacingRight
    Vector2 fireballDirection = isFacingRight ? Vector2.right : Vector2.left;

    // Set the direction of the fireball
    FireBall fireballScript = spawnedFireball.GetComponent<FireBall>();
    if (fireballScript != null)
    {
        fireballScript.SetDirection(fireballDirection);
    }

    // Flip fireball sprite to face the correct direction
    if (!isFacingRight)
    {
        Vector3 fireballScale = spawnedFireball.transform.localScale;
        fireballScale.x *= -1; // Flip the sprite horizontally
        spawnedFireball.transform.localScale = fireballScale;
    }
    }


}
