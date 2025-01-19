using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1,sfx2,sfx3;

    public void HurtSound(){
        src.clip = sfx1;
        src.Play();
    }
}
