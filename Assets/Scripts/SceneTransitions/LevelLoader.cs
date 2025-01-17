using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
    
    public void LoadGame(){
        Debug.Log("Carga el juego la pta madre");
        SceneManager.LoadScene("SampleScene");
        
    }
    public void Quit(){
        Application.Quit();
    }
}






