using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public int turns;
    public bool hasMovedThisTurn;

    void Awake()
    {
        Instance = this;
        turns = 1;
    }

    public void ChangeTurns(){
        hasMovedThisTurn = false;
        if(GameManager.Instance.GetState() == GameState.BattleModePink){
            Debug.Log("Changing to Blues turn.");
            GameManager.Instance.ChangeState(GameState.BattleModeBlue);
        }
        else if(GameManager.Instance.GetState() == GameState.BattleModeBlue){
            Debug.Log("Changing to Pinks turn.");
            GameManager.Instance.ChangeState(GameState.BattleModePink);
            if(turns == 10){
                GameManager.Instance.ChangeState(GameState.EndGame);
            }
            turns++;
        }
        
    }
}
