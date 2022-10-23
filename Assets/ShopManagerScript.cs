//Author: Evashna Pillay

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[4,4];
    public float coins;
    public Text CoinsTXT;
    public static ShopManagerScript Instance;
    public bool isPlacingNewUnit;
    private int latestPurchaseIdx;
    private List<ScriptableUnit> units;
    private Faction customerFaction;


    private void Awake()
    {
        Instance = this;

        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    void Start()
    {
   

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        //Price
        shopItems[2, 1] = 5;
        shopItems[2, 2] = 10;
        shopItems[2, 3] = 15;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;

    }

   
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            if (customerFaction == Faction.Blue) { 
                GameManager.Instance.BlueCoins = (int) coins;
                TurnManager.Instance.blueCoins.text = "Blue: " + GameManager.Instance.BlueCoins;
            } else { 
                GameManager.Instance.PinkCoins = (int)coins;
                TurnManager.Instance.pinkCoins.text = "Pink: " + GameManager.Instance.PinkCoins;
            }
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "Coins:" + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

            managePurchase(ButtonRef.GetComponent<ButtonInfo>().ItemID);

        }


    }

    private void managePurchase(int index)
    {
        isPlacingNewUnit = true;
        ShopButton.Instance.CloseShop();
        latestPurchaseIdx = index;
    }

    public void UpdateShop()
    {
        if (GameManager.Instance.state == GameState.BattleModeBlue)
        {
            customerFaction = Faction.Blue;
        }
        else
        {
            customerFaction = Faction.Pink;
        }

        if (customerFaction == Faction.Blue)
        {
            coins = (float)GameManager.Instance.BlueCoins;
        }
        else
        {
            coins = (float)GameManager.Instance.PinkCoins;
        }
        UnitManager.Instance.SelectedHero = null;
        CoinsTXT.text = "Coins:" + coins.ToString();
    }

    public void handlePlacement(Tile tile)
    {
        if (isAHomeTile(tile) && tile.OccupiedUnit==null) {
            var prefab = units[0].unitPrefab;
            int resourceIndex;
            if(latestPurchaseIdx == 2)
            {
                resourceIndex = 3;
            } else if(latestPurchaseIdx == 3)
            {
                resourceIndex = 2;
            } else
            {
                resourceIndex = 1;
            }
            if (customerFaction == Faction.Blue) { prefab = units[resourceIndex-1].unitPrefab; } else { prefab = units[resourceIndex + 2].unitPrefab; }

            var newUnit = Instantiate(prefab);
            tile.SetUnit(newUnit);

            isPlacingNewUnit = false;
        }
    }

    private bool isAHomeTile(Tile tile)
    {
        if(customerFaction == Faction.Blue)
        {
            if(tile.spriteRenderer.color == tile.homeBlue)
            {
                return true;
            } else
            {
                return false;
            }
        } else
        {
            if (tile.spriteRenderer.color == tile.homePink)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
