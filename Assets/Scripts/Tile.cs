using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public Color homeBlue, homePink, blue, pink, grey;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    public BaseUnit OccupiedUnit;
    public void Init(int colorInd)
    {
        switch (colorInd)
        {
            case 0:
                spriteRenderer.color = grey;
                break;
            case 1:
                spriteRenderer.color = homeBlue;
                break;
            case 2:
                spriteRenderer.color = homePink;
                break;
            case 3:
                spriteRenderer.color = blue;
                break;
            case 4:
                spriteRenderer.color = pink;
                break;
        }
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.state != GameState.BattleModeBlue && GameManager.Instance.state != GameState.BattleModePink) return;


        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.CanBeSelected() && !TurnManager.Instance.hasMovedThisTurn) UnitManager.Instance.SetSelectedUnit(OccupiedUnit); //If its my turn and I select another one of my own pieces, select the new piece.
            else
            {
                if (UnitManager.Instance.SelectedHero != null && UnitMayMove(UnitManager.Instance.SelectedHero, UnitManager.Instance.SelectedHero.OccupiedTile, this))
                {
                    // Enter combat
                    var enemy = (BaseUnit)OccupiedUnit;
                    CombatManager.Instance.battleunits = new List<BaseUnit>{UnitManager.Instance.SelectedHero, enemy};
                    GameManager.Instance.ChangeState(GameState.CombatMode, this);
                    UnitManager.Instance.SetSelectedUnit(null);
                    TurnManager.Instance.hasMovedThisTurn = true;
                }
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedHero != null && UnitMayMove(UnitManager.Instance.SelectedHero, UnitManager.Instance.SelectedHero.OccupiedTile, this))
            {
                // Unit takes over unoccupied hex
                SetUnit(UnitManager.Instance.SelectedHero);
                if (UnitManager.Instance.SelectedHero.Faction == Faction.Blue) spriteRenderer.color = blue;
                else spriteRenderer.color = pink;
                UnitManager.Instance.SetSelectedUnit(null);
                TurnManager.Instance.hasMovedThisTurn = true;
            }
        }

    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }

    public bool UnitMayMove(BaseUnit unit, Tile from, Tile to)
    {
        int distanceCanMove = 1;
        if(unit.GetType() == typeof(Rifleman))
        {
            distanceCanMove = 2;
        }

        double xdiff = from.transform.position.x - to.transform.position.x;
        double ydiff = from.transform.position.y - to.transform.position.y;
        double dist = Math.Sqrt(Math.Pow(xdiff,2)+ Math.Pow(ydiff, 2));

        if (dist < distanceCanMove + 0.1)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void killUnit(){
        Destroy(OccupiedUnit.gameObject);
    }
}
