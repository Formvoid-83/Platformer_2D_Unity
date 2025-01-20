using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public AudioSource LevelSrc;
    public AudioClip music1,music2;
    public void Level1Music(){
        LevelSrc.clip = music1;
        LevelSrc.loop = true;
        LevelSrc.Play();
    }
    public void Level2Music(){
        LevelSrc.clip = music2;
        LevelSrc.loop = true;
        LevelSrc.Play();
    }
    public void StopLevel1Music(){
        LevelSrc.clip = music1;
        LevelSrc.Stop();
    }
    public void StopLevel2Music(){
        LevelSrc.clip = music2;
        LevelSrc.Stop();
    }




}
