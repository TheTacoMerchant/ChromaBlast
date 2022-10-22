using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioSource combatSong;
    public AudioSource menuSong;
    public AudioSource transistionSound;

    public void SwitchSongs(){

        if(menuSong.isPlaying){
            
            StartCoroutine(SwitchToFight());
            
        }
        else{
            
            StartCoroutine(SwitchToMenu());
            
        }
    }

    public void EndSongs(){
        menuSong.Stop();
        combatSong.Stop();
    }

    IEnumerator SwitchToMenu(){
        combatSong.Stop();
        transistionSound.Play();
        yield return new WaitForSeconds(2);
        menuSong.Play();
        Debug.Log("Switch to Menu");
    }

    IEnumerator SwitchToFight(){
        menuSong.Stop();
        transistionSound.Play();
        yield return new WaitForSeconds(2);
        combatSong.Play();
        Debug.Log("Switch to Fight");
    }
}
