using UnityEngine;

public class Pit : MonoBehaviour
{

    [SerializeField] private LevelLoader levelLoader; // Reference to your LevelLoader script
    private GameObject gameManager; 
    private GameManager theManager; 
    private void Awake() {
        gameManager = GameObject.FindWithTag("GameManager");
        if(gameManager){
            theManager = gameManager.GetComponent<GameManager>();
        }
        
    }// Reference to your LevelLoader script

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player fell into the pit
        if (collision.CompareTag("PlayerHitBox"))
        {
            if(theManager){
                theManager.RestartGame();
            }
        }
    }
}

