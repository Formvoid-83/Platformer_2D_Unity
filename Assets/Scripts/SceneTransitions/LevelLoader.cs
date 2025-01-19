using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader: MonoBehaviour
{
    
    public void LoadGame(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
        SceneManager.LoadScene("SampleScene");
        
    }
    IEnumerator LoadLevel(int levelIndex){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelIndex);
    }
    public void Quit(){
        Application.Quit();
    }
}






