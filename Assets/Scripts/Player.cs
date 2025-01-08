using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;
    [SerializeField] private float speedVelocity;
    [SerializeField] private float jumpVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(inputH * speedVelocity, rb.linearVelocityY); 

        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }
    }
}
