using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;
    public int maxHealth = 100;
    private SpriteRenderer spriteRenderer;
    private float currentHealth;
    private Image healthBarFill;
    private Color originalColor;
    private bool isBlinking = false;
    [Header("Movement")]
    [SerializeField] private float speedVelocity;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask whatIsJumpable;
    [SerializeField] private Transform feet;
    [Header("Combat System")]
    [SerializeField] private float attackDamage;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadious;
    [SerializeField] private LayerMask whatCanReceiveDamage;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initialize health
        currentHealth = maxHealth;
        // Health bar reference
        GameObject healthBar = GameObject.FindWithTag("healthBarFill");
        if (healthBar != null)
        {
            healthBarFill = healthBar.GetComponent<Image>();
        }
        else
        {
            Debug.LogError("Health bar UI element not found!");
        }
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        throwAttack();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemySlime"))
        {
            var slime = collision.GetComponent<Slime>();
            if (slime != null) TakeDamage((int)slime.damage);
        }
    }

    private void throwAttack()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetTrigger("attack");
        }
    }
    private void Attack(){
        LivesSystem liveSystem;
        Collider2D[] touchedColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadious, whatCanReceiveDamage);
        foreach(Collider2D touchCol in touchedColliders){
            liveSystem = touchCol.gameObject.GetComponent<LivesSystem>();
            liveSystem.receiveDamage(attackDamage);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && amIGrounded())
        {
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }
    private bool amIGrounded(){
        return Physics2D.Raycast(feet.position, Vector3.down, groundDistance, whatIsJumpable);
    }

    private void Movement()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(inputH * speedVelocity, rb.linearVelocityY);
        if (inputH != 0)
        {
            animator.SetBool("running", true);
            if(inputH >0){
                transform.eulerAngles = Vector3.zero;
            }
            else{
                transform.eulerAngles = new Vector3(0,180,0);
            }
        }
        else
        {
            animator.SetBool("running", false);
        }
    }
    void TakeDamage(int damage)
    {
        if (!isBlinking)
        {
            currentHealth -= damage;
            StartCoroutine(BlinkEffect());
        }

        // Clamp health and update UI
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (healthBarFill != null) healthBarFill.fillAmount = currentHealth / maxHealth;
        Debug.Log(currentHealth);
        if (currentHealth <= 0) Die();
    }
    IEnumerator BlinkEffect()
    {
        isBlinking = true;
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.2f);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
        isBlinking = false;
    }

    void Die()
    {
        Debug.Log("Player is dead!");
        //gameController?.GameOver();
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(attackPoint.position, attackRadious);
    }
}
