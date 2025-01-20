using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    private LevelMusic levelMusic;
    private bool isTheGameOver;
    private float level;
    public static GameManager Instance;
    private float CurrentHealth = 100f;
    private float MaxHealth = 100f;

    /*public float CurrentHealth1 { get => CurrentHealth; set => CurrentHealth = value; }
    public float MaxHealth1 { get => MaxHealth; set => MaxHealth = value; }*/

    /*private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this; // Set this as the singleton instance
            DontDestroyOnLoad(gameObject); // Make this GameObject persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }
    }*/
    void Start(){
        isTheGameOver = false;
        levelMusic = GetComponent<LevelMusic>();
        level = SceneManager.GetActiveScene().buildIndex;
        if(levelMusic){
            if(level==1){
                levelMusic.Level1Music();
            }
            else if(level==2){
                levelMusic.Level2Music();
            }
        }
    }
    public void GameOver(){
        if(level==1){
            levelMusic.StopLevel1Music();
        }
        else if(level==2){
            levelMusic.StopLevel2Music();
        }
        isTheGameOver=true;
        Time.timeScale=0f;
        gameOverScreen.SetActive(true);
    }
    private void Update() {
        if(isTheGameOver && Input.anyKeyDown){
            RestartGame();
        }
    }
    public void RestartGame(){
        Time.timeScale=1f;
        isTheGameOver=false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
