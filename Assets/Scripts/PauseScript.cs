using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;

    public GameObject pauseUI;

    public void Resume(){
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Pause(){
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
}
