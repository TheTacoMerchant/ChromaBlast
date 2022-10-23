using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public int BlueScore = 0;
    public int BlueCoins = 0;

    public int PinkScore = 0;
    public int PinkCoins = 0;

    public GameObject victoryCanvas;
    public TextMeshProUGUI pinkWinner;
    public TextMeshProUGUI blueWinner;

    public AudioClip endTransistion;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public GameState GetState(){
        return state;
    }

    public void ChangeState(GameState gamestate, Tile tile = null)
    {
        GameState oldstate = state;
        state = gamestate;
        Debug.Log($"Just entered ${gamestate}");

        switch (gamestate)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                GameObject.Find("ShopPanel").SetActive(false);
                break;
            case GameState.SpawnUnits:
                UnitManager.Instance.SpawnUnits();
                break;
            case GameState.BattleModeBlue:
                break;
            case GameState.BattleModePink:
                break;
            case GameState.CombatMode:
                CombatManager.Instance.Combat(oldstate, tile);
                break;
            case GameState.EndGame:
                GameObject background = GameObject.Find("BackgroundAudio");
                BackgroundMusicScript stopping = (BackgroundMusicScript) background.GetComponent(typeof(BackgroundMusicScript));
                stopping.EndSongs();
                victoryCanvas.SetActive(true);
                if(GameManager.Instance.PinkScore > GameManager.Instance.BlueScore){
                    pinkWinner.enabled = true;
                    blueWinner.enabled = false;
                    Debug.Log("Pink Wins");
                }
                else if(GameManager.Instance.BlueScore > GameManager.Instance.PinkScore){
                    pinkWinner.enabled = false;
                    blueWinner.enabled = true;
                    Debug.Log("Blue Wins");
                }
                else{
                    if(GameManager.Instance.PinkCoins > GameManager.Instance.BlueCoins){
                        pinkWinner.enabled = true;
                        blueWinner.enabled = false;
                        Debug.Log("Pink Wins by coins");
                    }
                    else if(GameManager.Instance.BlueCoins > GameManager.Instance.PinkCoins){
                        pinkWinner.enabled = false;
                        blueWinner.enabled = true;
                        Debug.Log("Blue Wins by coins");
                    }
                    else{
                        pinkWinner.text = "DRAW";
                        pinkWinner.color = new Color(255f,255f,255f,1f);
                        Debug.Log("Draw");
                    }
                }
                AudioSource endAudio = GetComponent<AudioSource>();
                endAudio.clip = endTransistion;
                endAudio.Play();
                break;
        }
    }
}

public enum GameState
{
    GenerateGrid,
    SpawnUnits,
    BattleModeBlue,
    BattleModePink,
    CombatMode,
    EndGame
}
