using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

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

    public void ChangeState(GameState gamestate)
    {
        state = gamestate;
        Debug.Log($"Just entered ${gamestate}");

        switch (gamestate)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnUnits:
                UnitManager.Instance.SpawnUnits();
                break;
            case GameState.BattleModeBlue:
                break;
            case GameState.BattleModePink:
                break;
            case GameState.CombatMode:
                break;
            case GameState.EndGame:
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
