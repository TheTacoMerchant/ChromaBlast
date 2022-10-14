using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeTurns(int turns = 1){
        if(GameManager.Instance.GetState() == GameState.BattleModePink){
            GameManager.Instance.ChangeState(GameState.BattleModeBlue);
        }
        else if(GameManager.Instance.GetState() == GameState.BattleModeBlue){
            GameManager.Instance.ChangeState(GameState.BattleModePink);
            if(turns == 10){
                GameManager.Instance.ChangeState(GameState.EndGame);
            }
            turns = turns + 1;
        }
        
    }
}
