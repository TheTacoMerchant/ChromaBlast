using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> units;
    public BaseUnit SelectedHero;

    private void Awake()
    {
        Instance = this;

        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SetSelectedUnit(BaseUnit hero)
    {
        SelectedHero = hero;
    }

    public void SpawnUnits()
    {
        var rifle1pink = Instantiate(units[3].unitPrefab);
        GridManager.Instance.getTile(new Vector2(0, 0)).SetUnit(rifle1pink);
        var rifle2pink = Instantiate(units[3].unitPrefab);
        GridManager.Instance.getTile(new Vector2(1, 1)).SetUnit(rifle2pink);
        var shotgunpink = Instantiate(units[4].unitPrefab);
        GridManager.Instance.getTile(new Vector2(0, 1)).SetUnit(shotgunpink);
        var sniperpink = Instantiate(units[5].unitPrefab);
        GridManager.Instance.getTile(new Vector2(1, 0)).SetUnit(sniperpink);

        var rifle1blue = Instantiate(units[0].unitPrefab);
        GridManager.Instance.getTile(new Vector2(3, 2)).SetUnit(rifle1blue);
        var rifle2blue = Instantiate(units[0].unitPrefab);
        GridManager.Instance.getTile(new Vector2(4, 2)).SetUnit(rifle2blue);
        var shotgunblue = Instantiate(units[1].unitPrefab);
        GridManager.Instance.getTile(new Vector2(4, 1)).SetUnit(shotgunblue);
        var sniperblue = Instantiate(units[2].unitPrefab);
        GridManager.Instance.getTile(new Vector2(3, 3)).SetUnit(sniperblue);

        GameManager.Instance.ChangeState(GameState.BattleModeBlue);
    }

}
