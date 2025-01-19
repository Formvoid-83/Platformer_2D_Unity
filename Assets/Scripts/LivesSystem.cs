using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    [SerializeField] private float lives;
    [SerializeField] private AudioSource src;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hurtSound;
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
        HurtSound();
        lives -= damageDealt;
        if (lives <= 0)
        {
            DeathSound();
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
    public void DeathSound(){
        if(src!=null && deathSound!=null){
            src.clip = deathSound;
            src.Play();
        }
    }
    public void HurtSound(){
        if(src!=null && hurtSound!=null){
            src.clip = hurtSound;
            src.Play();
        }
    }
    
}
