using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader: MonoBehaviour
{
    public Animator transition;
    [SerializeField] private float transitionTime=1f;
    
    public void LoadGame(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
        //SceneManager.LoadScene("SampleScene");
        
    }
    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelIndex);
    }
    public void Quit(){
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {

            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
        }
    }
}






