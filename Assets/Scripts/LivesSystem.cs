using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    [SerializeField] private float lives;
    private bool isBlinking = false;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public float Lives { get => lives; set => lives = value; }

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void receiveDamage(float damageDealt){
        lives -= damageDealt;
        if(lives<=0){
            Destroy(this.gameObject);
        }
        StartCoroutine(BlinkEffect());
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
