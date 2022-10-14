using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;

    public bool CanBeSelected()
    {
        if (GameManager.Instance.state == GameState.BattleModeBlue && Faction == Faction.Blue) return true;
        if (GameManager.Instance.state == GameState.BattleModePink && Faction == Faction.Pink) return true;
        return false;

    }
}
