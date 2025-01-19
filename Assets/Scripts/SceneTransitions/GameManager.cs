using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    private bool isTheGameOver;

    void Start(){
        isTheGameOver = false;
    }
    public void GameOver(){
        isTheGameOver=true;
        Time.timeScale=0f;
        gameOverScreen.SetActive(true);
    }
    private void Update() {
        if(isTheGameOver && Input.anyKeyDown){
            RestartGame();
        }
    }
    private void RestartGame(){
        Time.timeScale=1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
