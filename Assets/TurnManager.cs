using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    private int turns = 1;
    public bool hasMovedThisTurn;
    public Text blueScore;
    public Text pinkScore;
    public Text turnLabel;
    public Text blueCoins;
    public Text pinkCoins;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeTurns(){
        hasMovedThisTurn = false;
        pinkScore.text = "Pink: " + GameManager.Instance.PinkScore;
        blueScore.text = "Blue: " + GameManager.Instance.BlueScore;
        if(GameManager.Instance.GetState() == GameState.BattleModePink){
            Debug.Log("Changing to Blues turn.");
            if(turns == 10){
                GameManager.Instance.ChangeState(GameState.EndGame);
            }
            turns++;
            turnLabel.text = "Turn: Blue";
            turnLabel.color = new Color(0.0f,35.0f,255.0f,1.0f);
            GameManager.Instance.PinkCoins += GameManager.Instance.PinkScore;
            pinkCoins.text = "Coins: " + GameManager.Instance.PinkCoins;
            GameManager.Instance.ChangeState(GameState.BattleModeBlue);
        }
        else if(GameManager.Instance.GetState() == GameState.BattleModeBlue){
            Debug.Log("Changing to Pinks turn.");
            turnLabel.text = "Turn: Pink";
            turnLabel.color = new Color(219.0f,0.0f,255.0f,1.0f);
            GameManager.Instance.BlueCoins += GameManager.Instance.BlueScore;
            blueCoins.text = "Coins: " + GameManager.Instance.BlueCoins;
            GameManager.Instance.ChangeState(GameState.BattleModePink);
        }
    }
}
