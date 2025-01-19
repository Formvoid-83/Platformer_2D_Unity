using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    [SerializeField] private float lives;
    private bool isBlinking = false;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isDead = false;

    public float Lives { get => lives; set => lives = value; }

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void receiveDamage(float damageDealt)
    {
        if (isDead) return; // Prevent further damage after death

        lives -= damageDealt;
        if (lives <= 0)
        {
            StartDeathSequence();
        }
        else
        {
            StartCoroutine(BlinkEffect());
        }
    }
    private void StartDeathSequence()
    {
        isDead = true; // Mark as dead to prevent repeated triggers

        // Check if the enemy has FlyingMovement for death animation
        FlyingMovement flyingMovement = GetComponent<FlyingMovement>();
        if (flyingMovement != null)
        {
            flyingMovement.DeathAnimation();
            //Debug.Log("BAT DEATH ANIMATION");
            // Optionally, delay destruction until the animation ends
            Destroy(gameObject, 1f); // Adjust delay based on animation length
        }
        else
        {
            Destroy(gameObject); // No animation, destroy immediately
        }
    }
    IEnumerator BlinkEffect()
    {
        isBlinking = true;
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.2f);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
        isBlinking = false;
    }
    
}
