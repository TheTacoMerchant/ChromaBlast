using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public int BlueScore = 0;
    public int BlueCoins = 0;

    public int PinkScore = 0;
    public int PinkCoins = 0;

    public GameObject victoryCanvas;
    public Text pinkWinner;
    public Text blueWinner;

    public AudioClip endTransistion;

    public string winnerByCombat = null;

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
                if(winnerByCombat != null)
                {
                    if(winnerByCombat == "blue")
                    {
                        pinkWinner.enabled = false;
                        blueWinner.enabled = true;
                    } else
                    {
                        pinkWinner.enabled = true;
                        blueWinner.enabled = false;
                    }
                }
                else if(PinkScore > BlueScore){
                    pinkWinner.enabled = true;
                    blueWinner.enabled = false;
                }
                else if(BlueScore > PinkScore){
                    pinkWinner.enabled = false;
                    blueWinner.enabled = true;
                }
                else{
                    if(PinkCoins > BlueCoins){
                        pinkWinner.enabled = true;
                        blueWinner.enabled = false;
                    }
                    else if(BlueCoins > PinkCoins){
                        pinkWinner.enabled = false;
                        blueWinner.enabled = true;
                    }
                    else{
                        pinkWinner.text = "DRAW";
                        pinkWinner.color = new Color(255f,255f,255f,1f);
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
