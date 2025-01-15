using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;
    [SerializeField] private float speedVelocity;
    [SerializeField] private float jumpVelocity;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetTrigger("attack");
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
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
}
