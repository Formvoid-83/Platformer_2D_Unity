using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float shotForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shotForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
